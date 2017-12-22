using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuctionsService;
using AuctionWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> Auctions()
        {
            AuctionsServiceClient AuctionService = new AuctionsServiceClient();
            return View(await AuctionService.GetAllAuctionItemsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Auctions(string SearchString)
        {
            if (SearchString != null)
            {
                AuctionsServiceClient AuctionService = new AuctionsServiceClient();
                AuctionItem[] Auctions = await AuctionService.GetAllAuctionItemsAsync();
                return View(Auctions.Where(x => x.BidCustomName == SearchString));
            }
            return RedirectToAction("Auctions");
        }

        public async Task<IActionResult> AuctionDetails(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Auctions");
            }
            AuctionsServiceClient AuctionService = new AuctionsServiceClient();
            return View(await AuctionService.GetAuctionItemAsync(id));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Bid(int ItemNumber, int BidPrice, string BidCustomName, string BidCustomPhone)
        {
            AuctionsServiceClient AuctionService = new AuctionsServiceClient();
            await AuctionService.ProvideBidAsync(ItemNumber, BidPrice, BidCustomName, BidCustomPhone);
            return RedirectToAction("Auctions");
        }
    }
}
