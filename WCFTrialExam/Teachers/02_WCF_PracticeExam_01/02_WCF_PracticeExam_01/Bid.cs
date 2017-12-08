using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _02_WCF_PracticeExam_01
{
    public class Bid
    {
        
        public int ItemNumber { get; set; }
        public string CustomName { get; set; }
        public decimal Price { get; set; }
        public string Phone { get; set; }

    }
}
