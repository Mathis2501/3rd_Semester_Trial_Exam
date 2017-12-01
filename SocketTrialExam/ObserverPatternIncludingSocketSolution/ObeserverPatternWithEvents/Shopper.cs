using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObeserverPatternWithEvents
{
    public class Shopper //this is the object
    {
        private string ShopperName { get; set; }
        public Shopper(string shopperName)
        {
            this.ShopperName = shopperName;
        }
        public void RecieveNewProductNotification(object sender, NewProductEventArgs e) //it has a mwthod that matches the signature of the delegate which the event is based on
                                                                                        //this is the update method
        {
            Console.WriteLine("Shopper {0} thanks for subscribing to our notifications. New product {1} has arrived.", this.ShopperName, e.NewProduct);
        }
    }
}
