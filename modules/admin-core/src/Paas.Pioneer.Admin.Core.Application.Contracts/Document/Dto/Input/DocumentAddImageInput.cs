using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input
{
    public class DocumentAddImageInput
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// 请求路径
        /// </summary>
        public string Url { get; set; }
    }
}