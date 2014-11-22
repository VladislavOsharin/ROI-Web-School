﻿namespace Crm.Admin.Models
 {
     using Domain;
     using System.ComponentModel.DataAnnotations;

     public class NewUserModel : IUser
     {
         int IUser.Id { get { return 0; } }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Login { get; set; }

         private NewPasswordModel _password;

         [Display(Name = "Password")]
         public NewPasswordModel Password { get { return _password; } }

         public void Save()
         {
             ServiceFactory.Resolve<IUserService>().Create(this, Password.Password);
         }
     }
 }