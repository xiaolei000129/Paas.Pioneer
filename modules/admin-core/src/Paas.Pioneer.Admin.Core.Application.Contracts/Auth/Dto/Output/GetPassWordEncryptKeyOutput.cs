using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output
{
    /// <summary>
    /// 获取密钥
    /// </summary>
    public class GetPassWordEncryptKeyOutput
    {
        /// <summary>
        /// key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string EncyptKey { get; set; }
    }
}
