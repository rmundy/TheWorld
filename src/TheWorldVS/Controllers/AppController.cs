using Microsoft.AspNet.Mvc;
using System;

namespace TheWorldVS.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}