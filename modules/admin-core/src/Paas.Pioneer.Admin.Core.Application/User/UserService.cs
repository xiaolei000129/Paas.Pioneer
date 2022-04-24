using Microsoft.Extensions.Options;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.User;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey;
using Paas.Pioneer.Admin.Core.Domain.Tenant;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Application.User
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : ApplicationService, IUserService
    {
        private readonly AppConfig _appConfig;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly RedisAdminKeys _redisAdminKeys;
        private readonly IRoleRepository _roleRepository;

        public UserService(
            IOptions<AppConfig> appConfig,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            ITenantRepository tenantRepository,
            RedisAdminKeys redisAdminKeys,
            IRoleRepository roleRepository
        )
        {
            _appConfig = appConfig.Value;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _tenantRepository = tenantRepository;
            _redisAdminKeys = redisAdminKeys;
            _roleRepository = roleRepository;
        }

        #region 获取登录人相关信息

        /// <summary>
        /// 获取登录人相关信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public async Task<ResponseOutput<AuthLoginOutput>> GetLoginUserAsync(Guid id)
        {
            var output = new ResponseOutput<AuthLoginOutput>();
            var entityDto = await _userRepository.GetAsync(expression: x => x.Id == id,
                selector: x => new AuthLoginOutput
                {
                    Id = x.Id,
                    NickName = x.NickName,
                    UserName = x.UserName
                });
            if (_appConfig.Tenant && entityDto?.TenantId.Value != Guid.Empty)
            {
                var tenant = await _tenantRepository.FirstAsync(x => x.Id == entityDto.TenantId);
                if (null != tenant)
                {
                    entityDto.TenantType = tenant.GetProperty<ETenantType>("TenantType");
                }
            }
            return output.Succees(entityDto);
        }

        #endregion

        #region 查询单条用户

        /// <summary>
        /// 查询单条用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        public async Task<ResponseOutput<UserAndRoleOutput>> GetAsync(Guid id)
        {
            var model = new UserAndRoleOutput()
            {
                Form = await GetUserInfoByIdAsync(id),
            };
            model.Form.RoleIds = (await _userRepository.GetUserRoleInfoById(id)).Select(x => x.Id);
            return ResponseOutput.Succees(model);
        }

        #endregion

        #region 查询角色下拉数据

        /// <summary>
        /// 查询角色下拉数据
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseOutput<SelectModel>> GetSelectAsync()
        {
            var model = new SelectModel()
            {
                Select = await _roleRepository.GetListAsync(x => true, x => new UserRoleInfo()
                {
                    Id = x.Id,
                    Name = x.Name,
                }),
            };
            return ResponseOutput.Succees(model);
        }

        #endregion

        #region 获取当前登录用户信息

        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseOutput<UserModelOutput>> GetBasicAsync()
        {
            if (!(CurrentUser.Id != Guid.Empty))
            {
                return ResponseOutput.Error<UserModelOutput>("未登录！");
            }

            return ResponseOutput.Succees(await GetUserInfoByIdAsync(CurrentUser.Id.Value));
        }

        #endregion

        #region 查询分页用户

        /// <summary>
        /// 查询分页用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<GetUserPageListOutput>>> GetPageListAsync(PageInput<UserModelInput> input)
        {
            var data = await _userRepository.GetResponseOutputPageListAsync(selector: x => new GetUserPageListOutput
            {
                UserName = x.UserName,
                CreationTime = x.CreationTime,
                Id = x.Id,
                Name = x.UserName,
                NickName = x.NickName,
                Enabled = x.Enabled,
                Remark = x.Remark,
            },
            x => x.OrderByDescending(p => p.CreationTime),
            input);
            var userIds = data.Data.List.Select(x => x.Id);
            var userRoleList = await _userRepository.GetUserRoleInfoById(userIds);
            foreach (var item in data.Data.List)
            {
                item.RoleNames = userRoleList.Where(x => x.UserId == item.Id).Select(x => x.Name);
            }
            return data;
        }

        #endregion

        #region 新增用户

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> AddAsync(UserAddInput input)
        {
            if (input.Password.IsNullOrEmpty())
            {
                input.Password = "111111";
            }

            input.Password = MD5Encrypt.Encrypt32(input.Password);

            var entity = ObjectMapper.Map<UserAddInput, Ad_UserEntity>(input);
            var user = await _userRepository.InsertAsync(entity);

            if (input.RoleIds != null && input.RoleIds.Any())
            {
                var roles = input.RoleIds.Select(a => new Ad_UserRoleEntity { UserId = user.Id, RoleId = a });
                await _userRoleRepository.InsertManyAsync(roles);
            }

            return ResponseOutput.Succees("添加成功！");
        }

        #endregion

        #region 修改用户

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateAsync(UserUpdateInput input)
        {
            var user = await _userRepository.GetAsync(input.Id);
            if (user == null || user.Id == Guid.Empty)
            {
                throw new BusinessException("用户不存在！");
            }

            ObjectMapper.Map(input, user);
            await _userRepository.UpdateAsync(user);

            await _userRoleRepository.DeleteAsync(a => a.UserId == user.Id);

            if (input.RoleIds != null && input.RoleIds.Any())
            {
                var roles = input.RoleIds.Select(a => new Ad_UserRoleEntity { UserId = user.Id, RoleId = a });
                await _userRoleRepository.InsertManyAsync(roles);
            }

            return ResponseOutput.Succees("修改成功！");
        }

        #endregion

        #region 更新用户基本信息

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateBasicAsync(UserUpdateBasicInput input)
        {
            var entity = await _userRepository.GetAsync(input.Id);
            entity = ObjectMapper.Map(input, entity);
            await _userRepository.UpdateAsync(entity);

            //清除用户缓存
            await RedisHelper.DelAsync(string.Format(_redisAdminKeys.UserInfo, input.Id));

            return ResponseOutput.Succees("修改成功！");
        }

        #endregion

        #region 更新用户密码

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> ChangePasswordAsync(UserChangePasswordInput input)
        {
            if (input.ConfirmPassword != input.NewPassword)
            {
                throw new BusinessException("新密码和确认密码不一致！");
            }

            var entity = await _userRepository.GetAsync(input.Id);
            var oldPassword = MD5Encrypt.Encrypt32(input.OldPassword);
            if (oldPassword != entity.Password)
            {
                throw new BusinessException("旧密码不正确！");
            }

            input.Password = MD5Encrypt.Encrypt32(input.NewPassword);

            entity = ObjectMapper.Map(input, entity);
            await _userRepository.UpdateAsync(entity);

            return ResponseOutput.Succees("修改成功！");
        }

        #endregion

        #region 删除用户

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees("删除成功！");
        }

        #endregion

        #region 批量删除用户

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="ids">用户id集合</param>
        /// <returns></returns>
        public async Task<IResponseOutput> BatchSoftDeleteAsync(Guid[] ids)
        {
            await _userRoleRepository.DeleteAsync(a => ids.Contains(a.UserId));
            await _userRepository.DeleteAsync(a => ids.Contains(a.Id));
            return ResponseOutput.Succees("删除成功！");
        }

        #endregion

        #region 私有方法

        #region 根据用户Id，获取用户基础信息

        /// <summary>
        /// 根据用户Id，获取用户基础信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<UserModelOutput> GetUserInfoByIdAsync(Guid id)
        {
            return await _userRepository.GetAsync(expression: x => x.Id == id, selector: x => new UserModelOutput()
            {
                Id = x.Id,
                CreationTime = x.CreationTime,
                CreatorId = x.CreatorId,
                UserName = x.UserName,
                Password = x.Password,
                NickName = x.NickName,
                Avatar = x.Avatar,
                Enabled = x.Enabled,
                Remark = x.Remark,
            });
        }

        #endregion

        #endregion
    }
}