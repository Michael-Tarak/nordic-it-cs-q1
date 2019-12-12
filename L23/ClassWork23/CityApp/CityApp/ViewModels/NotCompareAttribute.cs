using System;
using System.ComponentModel.DataAnnotations;

namespace CityApp.ViewModels
{
    public class NotCompareAttribute : ValidationAttribute
    {
        public string Property { get; set; }

        public NotCompareAttribute(string property)
        {
            Property = property;
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(Property);
            var propertyValue = property.GetValue(validationContext.ObjectInstance);
            if (Equals(value, propertyValue))
            {
                return new ValidationResult($"Значение свойства  {Property} совпадает");
            }
            return ValidationResult.Success;
        }
    }
}
