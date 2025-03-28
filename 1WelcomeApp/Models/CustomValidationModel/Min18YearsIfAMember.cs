﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1WelcomeApp.Models.CustomValidationModel
{
    public class Min18YearsIfAMemberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId <= (byte)MemberShipTypes.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (!customer.Birthdate.HasValue)
            {
                return new ValidationResult("Please input BirthDate");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return age >= 18 ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to go on a membership");

        }
    }
}