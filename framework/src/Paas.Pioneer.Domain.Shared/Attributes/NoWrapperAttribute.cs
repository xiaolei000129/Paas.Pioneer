using System;

namespace Paas.Pioneer.Domain.Shared
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class NoWrapperAttribute : Attribute
    {
    }
}
