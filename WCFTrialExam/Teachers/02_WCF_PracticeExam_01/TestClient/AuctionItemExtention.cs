using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient.AuctionService
{
    public partial class AuctionItem
    {
        public override string ToString()
        {
            return $"Result: \n Name: {BidCustomerName},\n RatingPrice: {RatingPrice}";
        }
        public int MyProperty { get; set; }
    }
}
