using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.MiniPrograms.EntityFrameworkCore
{
    public class MiniProgramsModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MiniProgramsModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}