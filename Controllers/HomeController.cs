using Microsoft.AspNetCore.Mvc;
using SearchingOMDB.Models;
using Flurl.Http;
using System.Diagnostics;

namespace SearchingOMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        [HttpGet]
        public IActionResult MovieSearchForm() 
        {
            return View("MovieSearch"); 
        }

        [HttpPost]
        public IActionResult MovieSearchResults(string Title)
        {
            string apiUrl = $"http://www.omdbapi.com/?t={Title}&apikey=5599940f";
            var apiTask = apiUrl.GetJsonAsync<Movie>();
            apiTask.Wait();
            Movie result = apiTask.Result;


            return View("MovieSearch", result);
        }












        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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