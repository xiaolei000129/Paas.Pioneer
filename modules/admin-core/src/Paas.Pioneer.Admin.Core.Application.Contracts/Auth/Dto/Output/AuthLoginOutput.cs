using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output
{
    public class AuthLoginOutput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 租户类型
        /// </summary>
        public ETenantType? TenantType { get; set; }
    }
}