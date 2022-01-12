using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input
{
    public class PermissionUpdateDotInput
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public EPermissionType Type { get; set; } = EPermissionType.Dot;

        /// <summary>
        /// 父级节点
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 关联接口
        /// </summary>
        public IEnumerable<Guid> ApiIds { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
    }
}