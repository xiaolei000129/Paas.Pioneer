namespace Paas.Pioneer.AutoWrapper.Base
{
    public abstract class OptionBase
    {
        /// <summary>
        /// 在响应中显示IsError属性。
        /// </summary>
        public bool ShowIsErrorFlagForSuccessfulResponse { get; set; } = false;

        /// <summary>
        /// 用于指示包装器是否仅用于API项目。  
        /// 当你想在Angular、MVC、React或Blazor项目中使用包装器时，把它设为false。  
        /// </summary>
        public bool IsApiOnly { get; set; } = true;

        /// <summary>
        /// 告诉包装器忽略包含HTML的字符串的验证 
        /// </summary>
        public bool BypassHTMLValidation { get; set; } = false;

        /// <summary>
        /// 将Api路径段设置为validate。 默认值为“/api”。 仅当IsApiOnly设置为false时有效。  
        /// </summary>
        public string WrapWhenApiPathStartsWith { get; set; } = "/api";

        /// <summary>
        /// 告诉包装器忽略具有空值的属性。 默认是正确的  .
        /// </summary>
        public bool IgnoreNullValue { get; set; } = true;

        /// <summary>
        /// 告诉包装器使用驼峰式大小写作为响应格式。 默认是正确的。  
        /// </summary>
        public bool UseCamelCaseNamingStrategy { get; set; } = true;
    }
}
