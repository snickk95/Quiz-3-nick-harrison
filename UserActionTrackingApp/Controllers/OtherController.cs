using Microsoft.AspNetCore.Mvc;

using UserActionTrackingApp.Models;
using UserActionTrackingApp.Services;
namespace UserActionTrackingApp.Controllers
{
    public class OtherController : BaseController
    {
        HomeViewModel _viewModel;
        public int currentPageCount;
        private IPageCount pageCount;
        public int Totalpagecount;

        public OtherController(IPageCount newPageCount)
        {
            pageCount = newPageCount;
            Totalpagecount = 0;
            _viewModel = new HomeViewModel();
        }

        public IActionResult Index()
        {
            //set the total pagecount to the cookie
            Totalpagecount = getCookieValue("Other");
            //increase page count
            Totalpagecount++;
            //update the cookie
            UpdateCookie("Other", Totalpagecount);
            //incrment current page count 
            currentPageCount = pageCount.IncrementPageCount("other");
            
            //set the values for the model to return
            _viewModel.totalCount = Totalpagecount;
            _viewModel.currentCount = currentPageCount;

            //return the model back to the view 
            return View(_viewModel);
        }
    }
}
