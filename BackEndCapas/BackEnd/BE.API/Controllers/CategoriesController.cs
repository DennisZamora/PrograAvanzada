using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.Controllers
{
    public class CateogoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
