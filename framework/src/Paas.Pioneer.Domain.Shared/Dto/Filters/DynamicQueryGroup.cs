using Paas.Pioneer.Domain.Shared.BaseEnum;
using System.Collections.Generic;

namespace Paas.Pioneer.Domain.Shared.Dto.Filters
{
    public class DynamicQueryGroup
    {
        public GroupType Type { get; set; }
        public List<DynamicQueryGroup> Groups { get; set; }
        public List<DynamicQueryCondition> Conditions { get; set; }
    }
}