using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission13.Models;

namespace Mission13.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }

        // query the data and return it in a ViewBag
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bowlerTeam"];

            var types = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
