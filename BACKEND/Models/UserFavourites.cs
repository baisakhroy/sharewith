using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("UserFavourites")]

    public class UserFavourites
    {
        [Key]
        public int FavID {get; set;}
        public int ContentID {get; set;}
        public int FileID {get; set;}
        public int UserID {get; set;}
        public string CreatedBy {get; set;}
        public DateTime CreatedOn {get; set;}
        public bool IsDelete {get; set;}
        public DateTime ModifiedOn {get; set;}


        
    }
}