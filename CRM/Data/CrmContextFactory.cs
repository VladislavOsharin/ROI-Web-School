﻿namespace Crm.Data
 {
     public class CrmContextFactory : ICrmContextFactory
     {
         private static ICrmContextFactory _current = new CrmContextFactory();

         private CrmContextFactory() { }

         public ICrmContext CreateContext()
         {
             return new CrmContext();
         }

         public ICrmContext CreateContext(string nameOrConnectionString)
         {
             return new CrmContext(nameOrConnectionString);
         }

         public static ICrmContextFactory Current
         {
             get { return _current; }
             set { _current = value; }
         }

         public static ICrmContext Get()
         {
             return Current.CreateContext();
         }

         public static ICrmContext Get(string nameOrConnectionString)
         {
             return Current.CreateContext(nameOrConnectionString);
         }
     }
 }