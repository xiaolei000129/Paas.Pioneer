using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
using System.ComponentModel.DataAnnotations;
namespace Paas.Pioneer.Admin.Core.Application.Contracts.{{model.taxon}}.Dto.Input
{
    /// <summary>
    /// {{model.function_module}}修改
    /// </summary>
    public class Update{{model.taxon}}Input
    {
        {{~ for item in model.low_code_table_config_list ~}}

        /// <summary>
        /// {{ item.column_comment }}
        /// </summary>
        {{ if item.column_key -}}[NotEqual("00000000-0000-0000-0000-000000000000", ErrorMessage = "请输入{{ item.column_comment }}")]{{"\n"}}{{- end -}}
        {{ if !item.is_column_nullable -}}[Required(ErrorMessage = "请输入{{ item.column_comment }}")]{{"\n"}}{{- end -}}
        {{ if item.max_length!=0 -}}[MaxLength({{ item.max_length }},ErrorMessage ="{{ item.column_comment }}长度不能超过{{ item.max_length }}")]{{"\n"}}{{- end -}}
        public {{ item.net_type }} {{ item.column_name }} { get; set; }

        {{~ end ~}}
    }
}