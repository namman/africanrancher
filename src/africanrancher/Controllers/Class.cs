using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace africanrancher.Controllers
{
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
