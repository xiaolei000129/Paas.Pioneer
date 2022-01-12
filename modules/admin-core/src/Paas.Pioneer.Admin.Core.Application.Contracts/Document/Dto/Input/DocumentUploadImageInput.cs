using Microsoft.AspNetCore.Http;
using Paas.Pioneer.Domain.Shared.ModelValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input
{
    public class DocumentUploadImageInput
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        public IFormFile File { get; set; }

        /// <summary>
        /// 文档编号
        /// </summary>
        [Required(ErrorMessage = "请输入正确id")]
        [NotEqual("00000000-0000-0000-0000-000000000000", ErrorMessage = "请输入正确id")]
        public Guid Id { get; set; }
    }
}