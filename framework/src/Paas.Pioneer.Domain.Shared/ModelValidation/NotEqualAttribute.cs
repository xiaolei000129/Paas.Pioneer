using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Domain.Shared.ModelValidation
{
    /// <summary>
    /// 不等于模型验证
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class NotEqual : ValidationAttribute
    {
        private readonly string _value;

        public NotEqual(string value)
        {
            _value = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.Compare(value.ToString(), _value, true) == 0)
            {
                return new ValidationResult(base.ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
