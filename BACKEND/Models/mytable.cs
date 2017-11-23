using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("mytable")]
   public class mytable
    {
        [Key]
        public int ID {get; set;}
        public int FileID {get; set;}
        public string Sharewith {get; set;}
        public string UserID {get; set;}
    }
}