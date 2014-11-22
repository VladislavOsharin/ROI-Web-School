﻿namespace Crm.Admin.Helpers
 {
     using System;
     using System.Collections.Generic;

     public static class EnumerableHelpers
     {
         public static T Element<T>(this IEnumerable<T> enumerable)
         {
             throw new NotSupportedException();
         }
     }
 }