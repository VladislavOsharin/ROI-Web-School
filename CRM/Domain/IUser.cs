﻿namespace Crm.Domain
 {
     public interface IUser
     {
         int Id { get; }
         string FirstName { get; }
         string LastName { get; }
         string Login { get; }
     }
 }