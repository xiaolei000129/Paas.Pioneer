using Newtonsoft.Json;

namespace Paas.Pioneer.AutoWrapper.Helpers
{
    public static class JSONHelper
    {
        public static JsonSerializerSettings GetJSONSettings(bool ignoreNull = true, ReferenceLoopHandling referenceLoopHandling = ReferenceLoopHandling.Ignore, bool useCamelCaseNaming = true)
        {
            return new CamelCaseContractResolverJsonSettings().GetJSONSettings(ignoreNull, referenceLoopHandling, useCamelCaseNaming);
        }
    }
}
