using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
namespace Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Input
{
    /// <summary>
    /// {{model.function_module}}分页
    /// </summary>
    public class Get{{model.taxon}}PageListInput
    {
        {{~ for item in model.low_code_table_config_list ~}}
        /// <summary>
        /// {{ item.column_comment }}
        /// </summary>
        public {{ item.net_type }} {{ item.column_name }} { get; set; }

        {{~ end ~}}
    }
}