using System.ComponentModel.DataAnnotations;

namespace L23_C02_asp_net_core_app_final.Attributes
{
	public class DiffentValuesAttribute : ValidationAttribute
	{
		public string OtherProperty { get; }

		public DiffentValuesAttribute(string otherProperty)
		{
			OtherProperty = otherProperty;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var property = validationContext.ObjectType.GetProperty(OtherProperty);
			if (property == null)
			{
				return new ValidationResult($"Member with specified name {OtherProperty} is not found");
			}

			var propertyValue = property.GetValue(validationContext.ObjectInstance);
			if (Equals(value, propertyValue))
			{
				return new ValidationResult($"The specified value are equal to member value {OtherProperty}");
			}

			return ValidationResult.Success;
		}
	}
}
