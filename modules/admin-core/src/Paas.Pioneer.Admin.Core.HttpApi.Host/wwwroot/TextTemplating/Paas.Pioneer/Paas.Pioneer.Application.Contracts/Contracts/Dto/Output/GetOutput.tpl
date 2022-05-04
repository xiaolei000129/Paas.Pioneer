using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
namespace Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Output
{
    /// <summary>
    /// {{model.function_module}}获取
    /// </summary>
    public class Get{{model.taxon}}Output
    {
        {{~ for item in model.low_code_table_config_list ~}}

        /// <summary>
        /// {{ item.column_comment }}
        /// </summary>
        public {{ item.net_type }} {{ item.column_name }} { get; set; }

        {{~ end ~}}
    }
}