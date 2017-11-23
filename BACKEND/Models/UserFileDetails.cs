using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("UserFileDetails")]

    public class UserFileDetails
    {
        [Key]
        public int FileID {get; set;}
        public int ContentID {get; set;}
        public int UserID {get; set;}
        public string FilePath {get; set;}
        public string FileName {get; set;}
        public string FileType {get; set;}
        public bool IsGraphCreated {get; set;}
        public bool IsPrivate {get; set;}
        public string CreatedBy {get; set;}
        public DateTime CreatedOn {get; set;}
        public bool IsDelete {get; set;}
        public DateTime ModifiedOn {get; set;}


        
    }
}