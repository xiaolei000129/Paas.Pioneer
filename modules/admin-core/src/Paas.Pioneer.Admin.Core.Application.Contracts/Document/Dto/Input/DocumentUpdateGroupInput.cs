using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Domain.Shared.ModelValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input
{
    public class DocumentUpdateGroupInput
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required(ErrorMessage = "请输入正确文章信息")]
        [NotEqual("00000000-0000-0000-0000-000000000000", ErrorMessage = "请输入正确id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 父级节点
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public EDocumentType Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 命名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 打开
        /// </summary>
        public bool Opened { get; set; }
    }
}