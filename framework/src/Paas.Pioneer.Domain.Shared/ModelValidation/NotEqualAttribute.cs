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
		private readonly object _value;
		public NotEqual(object value)
		{
			if (value == null)
			{
				throw new Exception("参数错误");
			}
			_value = value;
		}

		protected override ValidationResult IsValid(
		object value, ValidationContext validationContext)
		{
			if (value.Equals(_value))
			{
				return new ValidationResult(GetErrorMessage());
			}
			return ValidationResult.Success;
		}

		public string GetErrorMessage()
		{
			return ErrorMessage;
		}
	}
}
