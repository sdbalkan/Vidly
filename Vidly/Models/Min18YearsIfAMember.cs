using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.DomainModels;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayasYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birtdate is required.");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;

            if (age < 18)
                return new ValidationResult("Customer should be at least 18 years old");
            else
                return ValidationResult.Success;

        }

    }
}