using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("UserContentDetails")]

    public class UserContentDetails
    {
        [Key]
        public int ContentID {get; set;}
        public int UserID {get; set;}
        public string Content{get; set;}
        public string MetaTags {get; set;}
        public bool IsPrivate {get; set;}
        public bool IsGraphCreated {get; set;}
        public string CreatedBy {get; set;}
        public DateTime CreatedOn {get; set;}
        public bool IsDelete {get; set;}
        public DateTime ModifiedOn {get; set;}

    }
}