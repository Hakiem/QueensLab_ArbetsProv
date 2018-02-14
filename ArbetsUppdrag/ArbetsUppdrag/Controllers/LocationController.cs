using System;
using System.Linq;
using ArbetsUppdrag.Models;
using ArbetsUppdrag.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArbetsUppdrag.Controllers
{
    public class LocationController : Controller
    {
        private ILocationsRepository<Location> _repository;

        public LocationController(ILocationsRepository<Location> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Geo Tracker";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Watcha know'bout mej";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Tasmania";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult GetRandomCity() => Json((from record in _repository.GetAll() select record).OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault());
    }
}
