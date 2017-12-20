using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_WebApi_praticeExam_01.Models
{
    public class Bid
    {
        public int ItemNumber { get; set; }
        public decimal Price { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }

    }
}