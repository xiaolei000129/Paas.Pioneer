using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input
{
    public class DocumentAddMenuInput
    {
        /// <summary>
        /// 父级节点
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public EDocumentType Type { get; set; }

        /// <summary>
        /// 命名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
    }
}