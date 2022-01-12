using Paas.Pioneer.Admin.Core.Domain.Shared.Const;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.TextTemplatingDefinition
{
    public class GenerateCodeFileUrl
    {
        public static string PaasPioneerHttpApiControllers(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerHttpApiControllers}{path}";

        public static string PaasPioneerApplicationContractsService(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationContractsService}{path}";

        public static string PaasPioneerApplicationContractsAddInput(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationContractsAddInput}{path}";

        public static string PaasPioneerApplicationContractsGetPageListInput(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationContractsGetPageListInput}{path}";

        public static string PaasPioneerApplicationContractsUpdateInput(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationContractsUpdateInput}{path}";

        public static string PaasPioneerApplicationContractsGetOutput(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationContractsGetOutput}{path}";

        public static string PaasPioneerApplicationContractsGetPageListOutput(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationContractsGetPageListOutput}{path}";

        public static string PaasPioneerApplicationService(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationService}{path}";

        public static string PaasPioneerApplicationMapConfig(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerApplicationMapConfig}{path}";

        public static string PaasPioneerEntityFrameworkCoreRepository(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerEntityFrameworkCoreRepository}{path}";

        public static string PaasPioneerDomainIRepository(string path) => $"{GenerateCodeFileUrlConsts.PaasPioneerDomainIRepository}{path}";

        public static string VueJs(string path) => $"{GenerateCodeFileUrlConsts.VueJs}{path}";

        public static string HtmlVue(string path) => $"{GenerateCodeFileUrlConsts.HtmlVue}{path}";
    }
}
