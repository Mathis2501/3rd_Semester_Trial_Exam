using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObeserverPatternWithEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentStore departmentStore = new DepartmentStore();
            Shopper shopper1 = new Shopper("John");

            departmentStore.NewProductArrived += shopper1.RecieveNewProductNotification; //subscribe
            departmentStore.NewProduct("Dishwasher"); //change state -> fire event -> john will be notified

            Shopper shopper2 = new Shopper("Mary");

            departmentStore.NewProductArrived += shopper2.RecieveNewProductNotification; //subscribe
            departmentStore.NewProduct("Washing Machine"); //change state -> fire event -> two people will get notified

            departmentStore.NewProductArrived -= shopper1.RecieveNewProductNotification; //unsubscribe

            departmentStore.NewProduct("Furniture"); //change state -> fire event -> only Mary will be notified

            Console.ReadLine();
        }
    }
}
