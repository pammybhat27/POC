using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC.Models {
    public class Min18YearsIfAMember : ValidationAttribute{
        protected override  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if(customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;


            if(customer.BirthDate == null)
                return new ValidationResult("BirthDate is required");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;


                if(age>= 18)
                    return ValidationResult.Success;

                return new ValidationResult("Customer should be at least 18 years old to go on membership ");


        }

      
    }
}