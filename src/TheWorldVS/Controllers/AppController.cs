using Microsoft.AspNet.Mvc;
using System;
using TheWorldVS.Services;
using TheWorldVS.ViewModels;

namespace TheWorldVS.Controllers.Web
{
    public class AppController : Controller
    {
        public IMailService MailService { get; private set; }

        public AppController(IMailService mailService)
        {
            this.MailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            this.MailService.SendMail(String.Empty,
                String.Empty,
                $"Contact Page from {cvm.Name} ({cvm.Email})",
                cvm.Message);
            return View();
        }
    }
}