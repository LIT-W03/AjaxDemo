using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxStuff.Web.Controllers
{
    public class AjaxViewModel
    {
        public IEnumerable<int> RandomNumbers { get; set; }
    }

    public class ReverseViewModel
    {
        public string ReversedText { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var x = 10;

            //var person = new 
            //{
            //    FirstName = "Avrumi",
            //    LastName = "Friedman",
            //    Age = 35
            //};

            return View();
        }

        public ActionResult GetRandom(int min, int max)
        {
            Random rnd = new Random();
            int amount = rnd.Next(5, 10);
            var randomNumbers = Enumerable.Range(1, amount).Select(i => rnd.Next(min, max));
            return Json(new { randomNumbers = randomNumbers }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Reverse(string text)
        {
            string reversed = new String(text.Reverse().ToArray());
            ReverseViewModel vm = new ReverseViewModel();
            vm.ReversedText = reversed;
            return Json(vm);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsernameExists(string username)
        {
            //go to database
            bool exists = username.ToLower() == "brooklyndev" || username.ToLower() == "johndoe";
            return Json(new { exists = exists });
        }

        public ActionResult GetCars()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car { Id = 1, Make = "Lamborghini", Model = "Aventador", Year = 2017 });
            cars.Add(new Car { Id = 2, Make = "Ferarri", Model = "LaFerrari", Year = 2017 });
            cars.Add(new Car { Id = 3, Make = "Bugatti", Model = "Chiron", Year = 2017 });
            return Json(cars, JsonRequestBehavior.AllowGet);
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

}