﻿namespace Crm.Domain
 {
     using System.Collections.Generic;

     public interface IUserService
     {
         void Create(IUser user, string password);
         IUser Read(int id);
         void Update(IUser user);
         void Delete(int id);
         void SetPassword(int id, string password);
         IUser Authenticate(string login, string password);
         IEnumerable<IUser> GetAll();
     }
 }