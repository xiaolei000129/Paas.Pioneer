using Paas.Pioneer.Admin.Core.Application.Contracts.Role;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Volo.Abp;

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

        public async Task<RoleGetOutput> GetAsync(Guid id)
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
            return result;
        }

        public async Task<Page<RoleListOutput>> GetPageListAsync(PageInput<RoleInput> input)
        {
            var key = input.Filter?.Name;
            Expression<Func<Ad_RoleEntity, bool>> expression = x => true;
            if (!key.IsNullOrEmpty())
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

        public async Task AddAsync(RoleAddInput input)
        {
            var entity = ObjectMapper.Map<RoleAddInput, Ad_RoleEntity>(input);
            await _roleRepository.InsertAsync(entity);
        }

        public async Task UpdateAsync(RoleUpdateInput input)
        {

            var entity = await _roleRepository.GetAsync(input.Id);
            if (!(entity?.Id != Guid.Empty))
            {
                throw new BusinessException("½ÇÉ«²»´æÔÚ£¡");
            }

            ObjectMapper.Map(input, entity);
            await _roleRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _roleRepository.DeleteAsync(m => m.Id == id);
        }

        public async Task BatchSoftDeleteAsync(Guid[] ids)
        {
            await _roleRepository.DeleteAsync(a => ids.Contains(a.Id));
            await _rolePermissionRepository.DeleteAsync(a => ids.Contains(a.RoleId));
        }
    }
}