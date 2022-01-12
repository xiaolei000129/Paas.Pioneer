using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input
{
    public class PermissionSaveTenantPermissionsInput
    {
        [Required(ErrorMessage = "租户不能为空！")]
        public Guid TenantId { get; set; }

        [Required(ErrorMessage = "权限不能为空！")]
        public List<Guid> PermissionIds { get; set; }
    }
}