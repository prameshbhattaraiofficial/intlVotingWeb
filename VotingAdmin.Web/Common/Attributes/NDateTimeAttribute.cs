using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace VotingAdmin.Web.Common.Attributes
{
    public class NDateTimeAttribute : ValidationAttribute
    {
        const string DefaultDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var invalidResult = new ValidationResult($"Invalid field '{validationContext.MemberName}'", new[] { validationContext.MemberName });
            if (value is null)
                return ValidationResult.Success;

            if (value is not string)
                return invalidResult;

            var dateTimeString = (string)value;
            if (string.IsNullOrWhiteSpace(dateTimeString))
                return ValidationResult.Success;

            //if (!DateTime.TryParseExact(dateTimeString, DefaultDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var _))
            //    return invalidResult;

            if (!DateTime.TryParse(dateTimeString, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
                return invalidResult;

            // Set the new value to the property
            PropertyInfo property = validationContext.ObjectInstance.GetType().GetProperty(validationContext.MemberName);
            property.SetValue(validationContext.ObjectInstance, dateTime.ToString(DefaultDateTimeFormat));

            return ValidationResult.Success;
        }
    }
}
