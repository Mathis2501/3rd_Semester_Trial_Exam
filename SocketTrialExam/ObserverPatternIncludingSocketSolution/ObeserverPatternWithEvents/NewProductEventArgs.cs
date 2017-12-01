using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObeserverPatternWithEvents
{ 
    public class NewProductEventArgs : EventArgs //since we are using the default delegate EventHandler, 
                                                 //we can supply it with a specific class 
    {
        public string NewProduct { get; set; }
        public NewProductEventArgs(string productName)
        {
            this.NewProduct = productName;
        }
    }
}
