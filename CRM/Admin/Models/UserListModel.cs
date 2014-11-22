﻿namespace Crm.Admin.Models
 {
     using Domain;
     using System.Collections.Generic;
     using System.ComponentModel.DataAnnotations;
     using System.Linq;

     public class UserListModel
     {
         public IEnumerable<UserModel> Users
         {
             get
             {
                 return ServiceFactory.Resolve<IUserService>().GetAll().Select(user => new UserModel(user));
             }
         }

         public int? DeleteId { get; set; }

         public int? EditId { get; set; }
     }
 }