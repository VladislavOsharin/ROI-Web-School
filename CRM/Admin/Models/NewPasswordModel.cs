﻿namespace Crm.Admin.Models
 {
     using System.Collections.Generic;
     using System.ComponentModel.DataAnnotations;

     public struct NewPasswordModel : IValidatableObject
     {
         [DataType(DataType.Password)]
         [Display(Name = "Password")]
         public string Password { get; set; }

         [DataType(DataType.Password)]
         [Display(Name = "Confirm Password")]
         public string ConfirmPassword { get; set; }

         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
         {
             return new[] {
				Password == ConfirmPassword
					? ValidationResult.Success
					: new ValidationResult(
						"Password and Confirmation Password must match.",
						new[] {"Password", "ConfirmPassword"}
					)
			};
         }
     }
 }