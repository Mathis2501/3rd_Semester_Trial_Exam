using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObeserverPatternWithEvents
{
    public class DepartmentStore //this is the subject
    {
        public event EventHandler<NewProductEventArgs> NewProductArrived; //here is the un-/subscription
        //since a delegate can hold multiple methods, we don't need a list of objects, but just a number of methods to call
        public void NewProduct(string productName)
        {
            if (NewProductArrived != null)
            {
                NewProductArrived(this, new NewProductEventArgs(productName)); //Firing the event is actually just calling a method which has an event keyword
                                                                               //this is the notify method
            }
        }
    }
}
