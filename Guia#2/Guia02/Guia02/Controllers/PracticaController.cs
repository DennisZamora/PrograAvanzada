using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guia02.Controllers
{
    public class PracticaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
