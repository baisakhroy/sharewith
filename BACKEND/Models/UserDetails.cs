using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("UserDetails")]

    public class UserDetails {

        [Key]
        public int UserID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string PasswordHash {get; set;}
        public string PasswordSalt {get; set;}
        public string PhotoUrl {get; set;}
        public string Provider {get; set;}
        public long ContactNo {get; set;}
        public DateTime DOB {get; set;}
        public string CreatedBy {get; set;}
        public DateTime CreatedOn {get; set;}
        public bool IsDelete {get; set;}
        public DateTime ModifiedOn{get; set;}
    }
}
