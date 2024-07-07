using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using TestTask2.Models;

namespace TestTask2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        IndexViewModel indexView;

        public HomeController( ApplicationContext context)
        {
            db = context;
            indexView = new IndexViewModel(GetDishes());
        }

        public IActionResult Index() => View(indexView);        
        public IActionResult Privacy() => View();

        [HttpGet]
        public IEnumerable<Dish> GetDishes()
        {            
            return db.Dishes;
        }

    }
}
