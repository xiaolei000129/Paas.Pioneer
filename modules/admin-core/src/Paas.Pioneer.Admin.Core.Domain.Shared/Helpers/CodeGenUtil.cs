using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Helpers
{
    /// <summary>
    /// 代码生成帮助类
    /// </summary>
    public static class CodeGenUtil
    {
        private static List<string> DefaultColumnList = new List<string> { "TenantId", "CreatorId", "LastModifierId", "IsDeleted" };

        public static string ConvertDataType(string dataType)
        {
            string nullableStr = "";
            if (string.IsNullOrEmpty(dataType)) return "";
            if (dataType.StartsWith("System.Nullable"))
            {
                nullableStr = "?";
                dataType = new Regex(@"(?i)(?<=\[)(.*)(?=\])").Match(dataType).Value; // 中括号[]里面值
            }
            switch (dataType)
            {
                case "System.Guid": return $"Guid{nullableStr}";
                case "System.String": return $"string{nullableStr}";
                case "System.Int32": return $"int{nullableStr}";
                case "System.Int64": return $"long{nullableStr}";
                case "System.Single": return $"float{nullableStr}";
                case "System.Double": return $"double{nullableStr}";
                case "System.Decimal": return $"decimal{nullableStr}";
                case "System.Boolean": return $"bool{nullableStr}";
                case "System.DateTime": return $"DateTime{nullableStr}";
                case "System.DateTimeOffset": return $"DateTimeOffset{nullableStr}";
                case "System.Byte": return $"byte{nullableStr}";
                case "System.Byte[]": return $"byte[]{nullableStr}";
                default:
                    break;
            }
            return dataType;
        }

        /// <summary>
        /// 数据类型转显示类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static string DataTypeToEff(string dataType)
        {
            if (string.IsNullOrEmpty(dataType)) return "";
            return dataType switch
            {
                "string" => "input",
                "int" => "inputnumber",
                "long" => "input",
                "float" => "input",
                "double" => "input",
                "decimal" => "input",
                "bool" => "switch",
                "Guid" => "input",
                "DateTime" => "datepicker",
                "DateTimeOffset" => "datepicker",
                _ => "input",
            };
        }

        public static IEnumerable<string> GetDefaultColumnList()
        {
            return DefaultColumnList;
        }

        // 是否通用字段
        public static bool IsCommonColumn(string columnName)
        {
            return DefaultColumnList.Contains(columnName);
        }
    }
}
