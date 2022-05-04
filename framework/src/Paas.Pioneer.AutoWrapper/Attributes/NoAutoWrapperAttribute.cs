using System;

namespace Paas.Pioneer.AutoWrapper.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class NoAutoWrapperAttribute : Attribute
    {
    }
}
