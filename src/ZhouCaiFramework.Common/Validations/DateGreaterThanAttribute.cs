using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Common.Validations
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;

            if (currentValue == null)
                return ValidationResult.Success;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException($"找不到属性 {_comparisonProperty}");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue == null)
                return ValidationResult.Success;

            if (currentValue <= comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
