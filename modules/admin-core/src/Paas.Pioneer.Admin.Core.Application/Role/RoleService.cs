using Paas.Pioneer.Admin.Core.Application.Contracts.Role;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Role
{
    public class RoleService : ApplicationService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RoleService(
            IRoleRepository roleRepository,
            IRolePermissionRepository rolePermissionRepository
        )
        {
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<ResponseOutput<RoleGetOutput>> GetAsync(Guid id)
        {
            var result = await _roleRepository.GetAsync(expression: x => x.Id == id,
                selector: x => new RoleGetOutput()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    Enabled = x.Enabled,
                    Name = x.Name,
                });
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<Page<RoleListOutput>>> GetPageListAsync(PageInput<RoleInput> input)
        {
            var key = input.Filter?.Name;
            Expression<Func<Ad_RoleEntity, bool>> expression = x => true;
            if (key.NotNull())
            {
                expression = expression.And(a => a.Name.Contains(key));
            }
            return await _roleRepository.GetResponseOutputPageListAsync(expression: expression,
                selector: x => new RoleListOutput
                {
                    Id = x.Id,
                    Code = x.Code,
                    CreationTime = x.CreationTime,
                    Description = x.Description,
                    Enabled = x.Enabled,
                    Name = x.Name,
                },
            x => x.OrderByDescending(p => p.Id),
            input);
        }

        public async Task<IResponseOutput> AddAsync(RoleAddInput input)
        {
            var entity = ObjectMapper.Map<RoleAddInput, Ad_RoleEntity>(input);
            await _roleRepository.InsertAsync(entity);

            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> UpdateAsync(RoleUpdateInput input)
        {

            var entity = await _roleRepository.GetAsync(input.Id);
            if (!(entity?.Id != Guid.Empty))
            {
                return ResponseOutput.Succees("角色不存在！");
            }

            ObjectMapper.Map(input, entity);
            await _roleRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _roleRepository.DeleteAsync(m => m.Id == id);

            return ResponseOutput.Succees("删除成功！");
        }

        public async Task<IResponseOutput> BatchSoftDeleteAsync(Guid[] ids)
        {
            await _roleRepository.DeleteAsync(a => ids.Contains(a.Id));
            await _rolePermissionRepository.DeleteAsync(a => ids.Contains(a.RoleId));

            return ResponseOutput.Succees("删除成功！");
        }
    }
}