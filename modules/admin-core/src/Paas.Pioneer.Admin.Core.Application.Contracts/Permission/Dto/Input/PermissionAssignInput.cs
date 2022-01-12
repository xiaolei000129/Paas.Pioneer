using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input
{
    public class PermissionAssignInput
    {
        [Required(ErrorMessage = "角色不能为空！")]
        public Guid RoleId { get; set; }

        [Required(ErrorMessage = "权限不能为空！")]
        public List<Guid> PermissionIds { get; set; }
    }
}