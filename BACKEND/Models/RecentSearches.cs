using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("RecentSearches")]

    public class RecentSearches
    {
        [Key]
        public int SearchID {get; set;}
        public int UserID {get; set;}
        public string SearchedContent {get; set;}
        public string CreatedBy {get; set;}
        public DateTime CreatedOn {get; set;}
        public bool IsDelete {get; set;}
        public DateTime ModifiedOn {get; set;}


        
    }
}