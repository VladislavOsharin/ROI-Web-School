﻿namespace Crm.Data
 {
     using System.Data.Entity;
     using Entities;

     internal class CrmContext : DbContext, ICrmContext
     {
         public IDbSet<User> Users { get; set; }
         public IDbSet<Client> Clients { get; set; }
         public IDbSet<Contact> Contacts { get; set; }
         public IDbSet<Operation> Operations { get; set; }

         public CrmContext() { }
         public CrmContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
     }
 }