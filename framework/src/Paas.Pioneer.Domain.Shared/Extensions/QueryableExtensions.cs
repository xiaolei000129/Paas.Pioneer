using Paas.Pioneer.Domain.Shared.BaseEnum;
using Paas.Pioneer.Domain.Shared.Dto.Filters;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace Paas.Pioneer.Domain.Shared.Extensions
{
    /// <summary>
    /// 拓展方法
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 动态生成查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> WhereDynamicFilter<T>(this IQueryable<T> query, DynamicFilterInfo group)
        {
            if (group == null || (group.Condition == null && group.Groups.IsNullOrEmpty()))
            {
                return query;
            }

            int index = 0;
            var whereClause = GenerateWhereClause(group, ref index);
            var lstValues = new List<object>();
            group.Travel((_, condition) => lstValues.Add(condition.Value));
            return query.Where(whereClause, lstValues.ToArray());
        }

        private static void Travel(this DynamicFilterInfo group,
            Action<DynamicFilterInfo, DynamicQueryCondition> conditionAction
        )
        {
            if (group.Condition != null)
            {
                conditionAction(group, group.Condition);
            }

            if (!group.Groups.IsNullOrEmpty())
            {
                foreach (var subGroup in group.Groups)
                {
                    Travel(subGroup, conditionAction);
                }
            }
        }

        private static string GenerateWhereClause(DynamicFilterInfo group, ref int index)
        {
            var lstConditions = new List<string>();

            if (group.Condition != null)
            {
                lstConditions.Add(ConvertToCondition(group.Condition, index++));
            }

            if (!group.Groups.IsNullOrEmpty())
            {
                foreach (var subGroup in group.Groups)
                {
                    lstConditions.Add(GenerateWhereClause(subGroup, ref index));
                }
            }

            return $"({lstConditions.JoinAsString(group.Type == GroupType.And ? " && " : " || ")})";
        }

        private static string ConvertToCondition(DynamicQueryCondition condition, int index)
        {
            string left = GetLeft(condition);
            string right = GetRight(index);
            switch (condition.Operator)
            {
                case DynamicQueryOperator.Equal:
                    return $"{left} == {right}";
                case DynamicQueryOperator.NotEqual:
                    return $"{left} != {right}";
                case DynamicQueryOperator.Greater:
                    return $"{left} > {right}";
                case DynamicQueryOperator.GreaterOrEqual:
                    return $"{left} >= {right}";
                case DynamicQueryOperator.Less:
                    return $"{left} < {right}";
                case DynamicQueryOperator.LessOrEqual:
                    return $"{left} <= {right}";
                case DynamicQueryOperator.StartWith:
                    return $"{left}.StartsWith({right})";
                case DynamicQueryOperator.NotStartWith:
                    return $"!{left}.StartsWith({right})";
                case DynamicQueryOperator.EndWith:
                    return $"{left}.EndsWith({right})";
                case DynamicQueryOperator.NotEndWith:
                    return $"!{left}.EndsWith({right})";
                case DynamicQueryOperator.Contain:
                    return $"{left}.Contains({right})";
                case DynamicQueryOperator.NotContain:
                    return $"!{left}.Contains({right})";
                default:
                    throw new InvalidOperationException($"Unknown dynamic query operator: {condition.Operator}");
            }
        }

        private static string GetLeft(DynamicQueryCondition condition)
        {
            return condition.Field;
        }

        private static string GetRight(int index)
        {
            return $"@{index}";
        }
    }
}
