﻿namespace Crm.Data.Entities
 {
     using System;
     using System.Collections.Generic;
     using System.ComponentModel.DataAnnotations;
     using System.ComponentModel.DataAnnotations.Schema;

     [Table("Clients")]
     public class Client
     {
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }

         [Required, StringLength(64, MinimumLength = 1)]
         public string FirstName { get; set; }

         [Required, StringLength(128, MinimumLength = 1)]
         public string LastName { get; set; }

         [Required, Column(TypeName = "date")]
         public DateTime DateOfBirth { get; set; }

         [InverseProperty("Client")]
         public virtual ICollection<Contact> Contacts { get; set; }

         [InverseProperty("Client")]
         public virtual ICollection<Operation> Operations { get; set; }
     }
 }