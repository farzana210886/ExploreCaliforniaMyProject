using Microsoft.AspNetCore.Mvc;

namespace ExploreCaliforniaMyProject.Controllers
{
    public class BlogOldController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Blog Posts"};
        }

        [Route("blog/{year:int}/{month:int}/{key}")]
        public IActionResult Post(int year, int month, string key) {

            //uses id as name to extract the value from somewhere in the request such as a query string or the body of a form post
            return new ContentResult {
                Content = string.Format("Year: {0}; Month: {1}; key: {2}",year, month, key) };

        }
    }
}
