using Eterna.DAL;
using Eterna.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Eterna.Controllers
{
    public class HomeController : Controller
    {

        private readonly EternaDbContext _context;  
        public HomeController(EternaDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            var cards = _context.Product.Include(x=>x.Category).ToList();   
            return View(cards);
        }


        public IActionResult Details(int Id)
        {
            var detail = _context.Product.
                Include(x=>x.Category). 
                FirstOrDefault(x=> x.Id== Id);
            return PartialView("_PortfolioDetailPartial", detail);
        }

    }
}