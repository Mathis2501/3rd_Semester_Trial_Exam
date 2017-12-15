using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _04_MVC_PracticeExam_01.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter something")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter something")]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string Author { get; set; }
    }
}
