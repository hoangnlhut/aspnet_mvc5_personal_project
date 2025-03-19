using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1WelcomeApp.Models.CustomValidationModel
{
    public class ReleaseDateRuleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (MovieFormViewModel)validationContext.ObjectInstance;
            if (movie.ReleaseDate == null)
            {
                return new ValidationResult("Release Date is required");
            }
            var yearRule = 1800;
            if (movie.ReleaseDate.Value.Year < yearRule)
            {
                return new ValidationResult("Release Date must be greater than or equal to 1800");
            }
            return ValidationResult.Success;
        }
    }
}