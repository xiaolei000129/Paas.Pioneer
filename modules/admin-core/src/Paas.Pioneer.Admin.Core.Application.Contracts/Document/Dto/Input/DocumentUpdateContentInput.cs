using Paas.Pioneer.Domain.Shared.ModelValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input
{
    public class DocumentUpdateContentInput
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required(ErrorMessage = "请选择文档菜单")]
        [NotEqual("00000000-0000-0000-0000-000000000000", ErrorMessage = "请选择文档菜单")]
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Html
        /// </summary>
        public string Html { get; set; }
    }
}