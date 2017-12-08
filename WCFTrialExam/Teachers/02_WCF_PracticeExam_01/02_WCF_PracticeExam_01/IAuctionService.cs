using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _02_WCF_PracticeExam_01
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuctionService" in both code and config file together.
    [ServiceContract]
    public interface IAuctionService
    {
        [OperationContract]
        List<AuctionItem> GetAllItems();

        [OperationContract]
        AuctionItem GetItemById(int itemNumber);

        [OperationContract]
        string MakeBid(Bid bid);
    }


    [DataContract]
    public class AuctionItem
    {
        [DataMember]
        public int ItemNumber { get; set; }

        [DataMember]
        public string ItemDescription { get; set; }

        [DataMember]
        public decimal RatingPrice { get; set; }

        [DataMember]
        public decimal BidPrice { get; set; }

        [DataMember]
        public string BidCustomerName { get; set; }

        [DataMember]
        public string BidCustomerPhone { get; set; }

        [DataMember]
        public DateTime BidTimeStamp { get; set; }

        

    }
}
