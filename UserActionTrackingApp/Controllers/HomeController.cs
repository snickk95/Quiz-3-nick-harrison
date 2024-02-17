using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserActionTrackingApp.Services;
using UserActionTrackingApp.Models;

namespace UserActionTrackingApp.Controllers
{
    
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        public int Totalpagecount;
        public int currentPageCount;
        private IPageCount pageCount;
         HomeViewModel _viewModel;
        public HomeController(ILogger<HomeController> logger, IPageCount newPageCount)
        {
            pageCount = newPageCount;
            Totalpagecount = 0;
            _logger = logger;
            _viewModel = new HomeViewModel();
        }

        public IActionResult Index()
        {
            //set the total pagecount to the cookie
            Totalpagecount = getCookieValue("Home");
            //increase page count
            Totalpagecount++;
            //update the cookie
            UpdateCookie("Home", Totalpagecount);

            //incrment the current page count
            currentPageCount = pageCount.IncrementPageCount("Home");
            
            //set the values for the model to return
            _viewModel.totalCount = Totalpagecount;
            _viewModel.currentCount = currentPageCount;

            return View(_viewModel);
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