using Microsoft.AspNetCore.Mvc;
using System;

using PartyEinladungen.Models;

using System.Linq;

namespace PartyEinladungen.Controllers
{
    public class HomeController : Controller
    {

        //public string Index()
        //{
        //    return "Hello World!";
        //}

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;

            // Die Property von ViewBag. kann beliebig gewähl werden, muss jedoch
            // in MyView.cshtml identisch sein.
            ViewBag.Gruesse = hour < 12 ? "Guten Morgen" : "Guten Tag";

            return View("MyView");  // --> Views/Home/MyView.cshtml

                                    // Wird nur return View(); angegeben, versucht das Programm
                                    // die View Index.cshtml zu rendern.
        }

        [HttpGet]
        public  ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(x => x.WillAttend == true));
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
