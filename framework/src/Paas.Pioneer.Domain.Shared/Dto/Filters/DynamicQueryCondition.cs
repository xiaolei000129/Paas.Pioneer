using Paas.Pioneer.Domain.Shared.BaseEnum;

namespace Paas.Pioneer.Domain.Shared.Dto.Filters
{
    public class DynamicQueryCondition
    {
        public string FieldName { get; set; }
        public DynamicQueryOperator Operator { get; set; }
        public object Value { get; set; }
    }
}