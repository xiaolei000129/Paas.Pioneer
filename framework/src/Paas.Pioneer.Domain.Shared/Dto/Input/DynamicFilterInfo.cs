using Paas.Pioneer.Domain.Shared.BaseEnum;
using System.Collections.Generic;

namespace Paas.Pioneer.Domain.Shared.Dto.Input
{
	public class DynamicFilterInfo
	{
		//
		// 摘要:
		//     属性名：Name
		//     导航属性：Parent.Name
		//     多表：b.Name
		public string Field
		{
			get;
			set;
		}

		//
		// 摘要:
		//     操作符
		public EDynamicFilterOperator Operator
		{
			get;
			set;
		}

		//
		// 摘要:
		//     值
		public object Value
		{
			get;
			set;
		}

		//
		// 摘要:
		//     Filters 下的逻辑运算符
		public EDynamicFilterLogic Logic
		{
			get;
			set;
		}

		//
		// 摘要:
		//     子过滤条件，它与当前的逻辑关系是 And
		//     注意：当前 Field 可以留空
		public List<DynamicFilterInfo> Filters
		{
			get;
			set;
		}
	}
}