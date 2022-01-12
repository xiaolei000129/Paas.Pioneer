using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input
{
    public class GetLowCodeTableConfigPadedInput
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 属性，字段名
        /// </summary>
        public string PropertyName { get; set; }
    }
}
