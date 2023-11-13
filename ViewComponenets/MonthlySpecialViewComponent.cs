using ExploreCaliforniaMyProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCaliforniaMyProject.ViewComponenets
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent : ViewComponent
    {
        private readonly BlogDataContext db;

        public MonthlySpecialsViewComponent(BlogDataContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke()
        {
            var specials = db.MonthlySpecials.ToArray();
            return View(specials);
        }

    }
}
