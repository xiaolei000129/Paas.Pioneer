using Newtonsoft.Json;
using Paas.Pioneer.AutoWrapper.Base;
using System.Collections.Generic;

namespace Paas.Pioneer.AutoWrapper
{
    public class AutoWrapperOptions : OptionBase
    {
        public ReferenceLoopHandling ReferenceLoopHandling { get; set; } = ReferenceLoopHandling.Ignore;

        public string SwaggerPath { get; set; } = "/swagger";

        public IEnumerable<AutoWrapperExcludePath> ExcludePaths { get; set; } = null;
    }
}
