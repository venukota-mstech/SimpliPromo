using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpliPromo.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpliPromo.Controllers
{
    public class MainController : Controller
    {
        private SimpliPromoDbContext _simpliPromoContext;
        public MainController(SimpliPromoDbContext context)
        {
            this._simpliPromoContext = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            SeedData.Seed(_simpliPromoContext);
            ViewBag.value = "SimpliPromo!!!";
            return View();
        }
    }
}
