﻿namespace Crm.Data
 {
     public interface ICrmContextFactory
     {
         ICrmContext CreateContext();
         ICrmContext CreateContext(string nameOrConnectionString);
     }
 }