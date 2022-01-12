using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    public enum EDynamicFilterOperator
    {
        //
        // 摘要:
        //     like
        Contains,
        StartsWith,
        EndsWith,
        NotContains,
        NotStartsWith,
        NotEndsWith,
        //
        // 摘要:
        //     =
        //     Equal/Equals/Eq 效果相同
        Equal,
        //
        // 摘要:
        //     =
        //     Equal/Equals/Eq 效果相同
        Equals,
        //
        // 摘要:
        //     =
        //     Equal/Equals/Eq 效果相同
        Eq,
        //
        // 摘要:
        //     <>
        NotEqual,
        //
        // 摘要:
        //     >
        GreaterThan,
        //
        // 摘要:
        //     >=
        GreaterThanOrEqual,
        //
        // 摘要:
        //     <
        LessThan,
        //
        // 摘要:
        //     <=
        LessThanOrEqual,
        //
        // 摘要:
        //     >= and <
        //     此时 Value 的值格式为逗号分割：value1,value2 或者数组
        Range,
        //
        // 摘要:
        //     >= and <
        //     此时 Value 的值格式为逗号分割：date1,date2 或者数组
        //     这是专门为日期范围查询定制的操作符，它会处理 date2 + 1，比如：
        //     当 date2 选择的是 2020-05-30，那查询的时候是 < 2020-05-31
        //     当 date2 选择的是 2020-05，那查询的时候是 < 2020-06
        //     当 date2 选择的是 2020，那查询的时候是 < 2021
        //     当 date2 选择的是 2020-05-30 12，那查询的时候是 < 2020-05-30 13
        //     当 date2 选择的是 2020-05-30 12:30，那查询的时候是 < 2020-05-30 12:31
        //     并且 date2 只支持以上 5 种格式 (date1 没有限制)
        DateRange,
        //
        // 摘要:
        //     in (1,2,3)
        //     此时 Value 的值格式为逗号分割：value1,value2,value3... 或者数组
        Any,
        //
        // 摘要:
        //     not in (1,2,3)
        //     此时 Value 的值格式为逗号分割：value1,value2,value3... 或者数组
        NotAny
    }
}
