using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guia02.Controllers
{
    public class GuiaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Guia()
        {
            return View();
        }
    }
}
