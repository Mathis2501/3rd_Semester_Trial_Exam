using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFPracticeExam
{
    [DataContract]
    public class Bid
    {
        [DataMember]
        public int ItemNumber { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string CustomName { get; set; }
        [DataMember]
        public string CustomPhone { get; set; }
    }
}