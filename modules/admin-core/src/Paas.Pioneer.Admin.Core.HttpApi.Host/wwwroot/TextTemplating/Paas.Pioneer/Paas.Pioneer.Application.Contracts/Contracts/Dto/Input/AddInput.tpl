using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
using System.ComponentModel.DataAnnotations;
namespace Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Input
{
    /// <summary>
    /// {{model.function_module}}添加
    /// </summary>
    public class Add{{model.taxon}}Input
    {
        {{~ for item in model.low_code_table_config_list ~}}

        /// <summary>
        /// {{ item.column_comment }}
        /// </summary>
        {{ if !item.is_column_nullable -}}[Required(ErrorMessage = "请输入{{ item.column_comment }}")]{{"\n"}}{{- end -}}
        {{ if item.max_length!=0 -}}[MaxLength({{ item.max_length }},ErrorMessage ="{{ item.column_comment }}长度不能超过{{ item.max_length }}")]{{"\n"}}{{- end -}}
        public {{ item.net_type }} {{ item.column_name }} { get; set; }
        
        {{~ end ~}}
    }
}