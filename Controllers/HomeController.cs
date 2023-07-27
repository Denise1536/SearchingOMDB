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

        [HttpGet]
        public IActionResult MovieNightForm()
        {
            return View("MovieNight");
        }

        [HttpPost]
        public IActionResult MovieNightResults(string Title1, string Title2, string Title3)
        {
            List<Movie> result = new List<Movie>();

            string apiUrl = $"http://www.omdbapi.com/?t={Title1}&apikey=5599940f";
            var apiTaskOne = apiUrl.GetJsonAsync<Movie>();
            apiTaskOne.Wait();
            result.Add(apiTaskOne.Result);

            string apiUrlTwo = $"http://www.omdbapi.com/?t={Title2}&apikey=5599940f";
            var apiTaskTwo = apiUrlTwo.GetJsonAsync<Movie>();
            apiTaskTwo.Wait();
            result.Add(apiTaskTwo.Result);

            string apiUrlThree = $"http://www.omdbapi.com/?t={Title3}&apikey=5599940f";
            var apiTaskThree = apiUrlThree.GetJsonAsync<Movie>();
            apiTaskThree.Wait();
            result.Add(apiTaskThree.Result);
            
            return View("MovieNight", result);



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