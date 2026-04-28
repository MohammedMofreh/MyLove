using Microsoft.AspNetCore.Mvc;
using MyLove.Models;
using System.Diagnostics;

namespace MyLove.Controllers
{
     public class HomeController : Controller
     {
          public IActionResult Index()
          {
               var model = new WeddingCountdownViewModel
               {
                    WeddingDate = new DateTime(2026, 10, 1, 0, 0, 0, DateTimeKind.Local),
                    StartDate = new DateTime(2025, 7, 16, 0, 0, 0, DateTimeKind.Local),
                    ServerNow = DateTime.Now
               };
               return View(model);
          }

          public IActionResult Privacy()
          {
               return View();
          }

          [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
          public IActionResult Error()
          {
               return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
          }
     }
}
