using Paas.Pioneer.Domain.Shared.BaseEnum;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

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
		public static IQueryable<T> WhereDynamicFilter<T>(this IQueryable<T> source, DynamicFilterInfo dynamicFilter)
		{
			if (dynamicFilter == null)
			{
				return source;
			}
			return source.Where(CreateString(dynamicFilter), dynamicFilter.Value);
		}

		/// <summary>
		/// 创建sql 语句
		/// </summary>
		/// <param name="dynamicFilter"></param>
		/// <returns></returns>
		private static string CreateString(DynamicFilterInfo dynamicFilter)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(dynamicFilter.Field);
			stringBuilder.Append(CreateOperator(dynamicFilter.Operator));
			stringBuilder.Append("@0");
			return stringBuilder.ToString();
		}

		/// <summary>
		/// 生成操作符号
		/// </summary>
		/// <param name="Operator"></param>
		/// <returns></returns>
		private static string CreateOperator(EDynamicFilterOperator Operator)
		{
			switch (Operator)
			{
				case EDynamicFilterOperator.Contains:
					return "";
				case EDynamicFilterOperator.StartsWith:
					return "";
				case EDynamicFilterOperator.EndsWith:
					return "";
				case EDynamicFilterOperator.NotContains:
					return "";
				case EDynamicFilterOperator.NotStartsWith:
					return "";
				case EDynamicFilterOperator.NotEndsWith:
					return "";
				case EDynamicFilterOperator.Equal:
					return "==";
				case EDynamicFilterOperator.Equals:
					return "==";
				case EDynamicFilterOperator.Eq:
					return "==";
				case EDynamicFilterOperator.NotEqual:
					return "!=";
				case EDynamicFilterOperator.GreaterThan:
					return "";
				case EDynamicFilterOperator.GreaterThanOrEqual:
					return "";
				case EDynamicFilterOperator.LessThan:
					return "";
				case EDynamicFilterOperator.LessThanOrEqual:
					return "";
				case EDynamicFilterOperator.Range:
					return "";
				case EDynamicFilterOperator.DateRange:
					return "";
				case EDynamicFilterOperator.Any:
					return "";
				case EDynamicFilterOperator.NotAny:
					return "";
				default:
					throw new Exception("没有找到对应的操作符");
			}
		}
	}
}
