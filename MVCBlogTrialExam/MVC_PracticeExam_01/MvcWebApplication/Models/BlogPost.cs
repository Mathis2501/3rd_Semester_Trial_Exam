using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebApplication.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [MinLength(50, ErrorMessage = "Blog posts must be 50 characters long")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string CreationDate { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
