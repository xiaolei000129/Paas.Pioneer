using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Paas.Pioneer.Admin.Core.Application.Contracts.User;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Helpers;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class UserController : AbpControllerBase
    {
        #region 构造函数

        private readonly UploadConfig _uploadConfig;
        private readonly UploadHelper _uploadHelper;
        private readonly IUserService _userService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uploadConfig"></param>
        /// <param name="uploadHelper"></param>
        /// <param name="userService"></param>
        public UserController(
            IOptionsMonitor<UploadConfig> uploadConfig,
            IOptionsMonitor<UploadHelper> uploadHelper,
            IUserService userService
        )
        {
            _uploadConfig = uploadConfig.CurrentValue;
            _uploadHelper = uploadHelper.CurrentValue;
            _userService = userService;
        }

        #endregion

        #region 获取当前登录用户信息

        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserModelOutput> GetBasic()
        {
            return await _userService.GetBasicAsync();
        }

        #endregion

        #region 查询单条用户

        /// <summary>
        /// 查询单条用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserAndRoleOutput> Get(Guid id)
        {
            return await _userService.GetAsync(id);
        }

        #endregion

        #region 查询角色下拉数据

        /// <summary>
        /// 查询角色下拉数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<SelectModel> GetSelect()
        {
            return await _userService.GetSelectAsync();
        }

        #endregion

        #region 查询分页用户

        /// <summary>
        /// 查询分页用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Page<GetUserPageListOutput>> GetPageList(PageInput<UserModelInput> input)
        {
            return await _userService.GetPageListAsync(input);
        }

        #endregion

        #region 新增用户

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] UserAddInput input)
        {
            await _userService.AddAsync(input);
        }

        #endregion

        #region 修改用户

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] UserUpdateInput input)
        {
            await _userService.UpdateAsync(input);
        }

        #endregion

        #region 删除用户

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDelete(Guid id)
        {
            await _userService.DeleteAsync(id);
        }

        #endregion

        #region 批量删除用户

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="ids">用户id集合</param>
        /// <returns></returns>
        [HttpPut]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _userService.BatchSoftDeleteAsync(ids);
        }

        #endregion

        #region 更新用户密码

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task ChangePassword([FromBody] UserChangePasswordInput input)
        {
            await _userService.ChangePasswordAsync(input);
        }

        #endregion

        #region 更新用户基本信息

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateBasic([FromBody] UserUpdateBasicInput input)
        {
            await _userService.UpdateBasicAsync(input);
        }

        #endregion

        #region 上传头像

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="file">文件流</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> AvatarUpload([FromForm] IFormFile file)
        {
            var config = _uploadConfig.Avatar;
            var res = await _uploadHelper.UploadAsync(file, config, new { CurrentUser.Id });
            if (res.Success)
            {
                return HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + res.Data.FileRequestPath;
            }
            throw new BusinessException(res.Msg ?? "上传失败！");
        }

        #endregion
    }
}