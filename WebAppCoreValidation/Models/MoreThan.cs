using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace WebAppCoreValidation.Models
{
    public sealed class MoreThan : ValidationAttribute, IClientModelValidator
    {
        public string PropertyName { get; }
        public string[] ErrorMessageList = {
            "The value {0} less than value {1}.",
            "Then Value of {0} ​​must be number",
            "Property error name",
        };

        public MoreThan(string propertyName)
        {
            PropertyName = propertyName; 
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {    
            object valueInitials = validationContext?                
                .ObjectInstance?
                .GetType()?
                .GetProperty(PropertyName)?
                .GetValue(validationContext.ObjectInstance); 

            if (valueInitials != null)
            {
                if (int.TryParse(valueInitials.ToString(), out int initials) && int.TryParse(value.ToString(), out int ends))
                {
                    if (initials > ends)
                    {
                        return GetValidationResultErrorMessage(ErrorMessage ?? ErrorMessageList[0], 
                            validationContext?.DisplayName, 
                            PropertyName);
                    }
                }
                else
                {
                    return GetValidationResultErrorMessage(ErrorMessage ?? ErrorMessageList[1], 
                        validationContext?.DisplayName);
                }
            }
            else
            {
                return GetValidationResultErrorMessage(ErrorMessage ?? ErrorMessageList[2]);
            }
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.Add("data-val","true");
            context.Attributes.Add("data-val-more-than", GetValidationClientErrorMessage(context));
            context.Attributes.Add("data-val-more-than-field", PropertyName);
        }

        private string GetValidationClientErrorMessage(ClientModelValidationContext context)
        {
            var str = (!string.IsNullOrEmpty(ErrorMessage)) ? ErrorMessage : ErrorMessageList[0];
            return string.Format(str, context.ModelMetadata?.GetDisplayName(), PropertyName);
        }

        private ValidationResult GetValidationResultErrorMessage(string message, string param1 = "", string param2 = "")
        {
            return new ValidationResult(string.Format(message, param1, param2));
        }
    }
}
