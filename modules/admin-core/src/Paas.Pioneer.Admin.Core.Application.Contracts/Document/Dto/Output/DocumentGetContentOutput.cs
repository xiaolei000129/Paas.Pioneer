using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Output
{
    public class DocumentGetContentOutput
    {
        /// <summary>
        /// ±àºÅ
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ãû³Æ
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// ÄÚÈÝ
        /// </summary>
        public string Content { get; set; }
    }
}