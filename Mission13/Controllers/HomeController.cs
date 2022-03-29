using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        // initialize the controller
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        // call the index page with the bowler table loaded
        public IActionResult Index(string bowlerTeam)
        {

            var bowler = _repo.Bowlers
                .Where(x => x.Team.TeamName == bowlerTeam || bowlerTeam == null)
                .ToList();

            return View(bowler);
        }

        // call the add bowler form
        [HttpGet]
        public IActionResult AddBowler()
        {
            return View();
        }

        // submit the add bowler form
        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            // throw errors if required fields not met
            if (ModelState.IsValid)
            {
                _repo.AddBowler(b);
                return RedirectToAction("Index", b);
            }
            else
            {

                return View();

            }
        }

        // call the edit bowler form with the form fields already populated
        [HttpGet]
        public IActionResult EditBowler(int id)
        {
            var bowler = _repo.Bowlers.Where(x => x.BowlerID == id).FirstOrDefault();
            return View(bowler);
        }

        // submit the edit bowler form
        [HttpPost]
        public IActionResult EditBowler(Bowler b)
        {
            // throw an error if required fields not met
            if (ModelState.IsValid)
            {
                _repo.EditBowler(b);
                return RedirectToAction("Index", b);
            }
            else
            {

                return View();

            }
        }

        // call the delete bowler page
        [HttpGet]
        public IActionResult DeleteBowler(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(bowler);
        }

        // submit the delete bowler form and remove the given bowler
        [HttpPost]
        public IActionResult DeleteBowler(Bowler b)
        {
            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }
}
