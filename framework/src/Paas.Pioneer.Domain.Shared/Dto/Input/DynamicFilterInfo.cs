using Paas.Pioneer.Domain.Shared.BaseEnum;
using Paas.Pioneer.Domain.Shared.Dto.Filters;
using System.Collections.Generic;

namespace Paas.Pioneer.Domain.Shared.Dto.Input
{
    public class DynamicFilterInfo
    {
        public GroupType Type { get; set; }
        public List<DynamicFilterInfo> Groups { get; set; }
        public DynamicQueryCondition Condition { get; set; }
    }
}