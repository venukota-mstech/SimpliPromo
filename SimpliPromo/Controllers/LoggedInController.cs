using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpliPromo.Controllers
{
    public class LoggedInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}