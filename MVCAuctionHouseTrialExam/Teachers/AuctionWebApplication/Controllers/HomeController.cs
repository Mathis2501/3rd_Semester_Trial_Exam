using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionWebApplication.Models;

namespace AuctionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.AuctionsServiceClient client;
        public HomeController(ServiceReference1.AuctionsServiceClient client)
        {
            this.client = client;
        }
        public async Task<IActionResult> Index()
        {
            
            client = new ServiceReference1.AuctionsServiceClient();
            var res = await client.GetAllAuctionItemsAsync();
            return View(res);
        }


        public async Task<IActionResult> Details(int id)
        {
            client = new ServiceReference1.AuctionsServiceClient();
            var res = await client.GetAllAuctionItemsAsync();
            var singleItem = res.Where(x => x.ItemNumber == id).SingleOrDefault();
            if (singleItem != null)
            {
                return View(singleItem);
            }
            else
            {
                Response.Redirect("/");
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(ServiceReference1.AuctionItem item)
        {
            ServiceReference1.AuctionsServiceClient client = new ServiceReference1.AuctionsServiceClient();
           string x = await client.ProvideBidAsync(item.ItemNumber, item.BidPrice, item.BidCustomName, item.BidCustomPhone);
            ViewBag.Response = x;
            return View();
        }

        public async Task<IActionResult> About(string name)
        {
            ServiceReference1.AuctionsServiceClient client = new ServiceReference1.AuctionsServiceClient();
            var res = await client.GetAllAuctionItemsAsync();
            var res2 = res.Where(x => x.BidCustomName == name);
            return View("index", res2);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
