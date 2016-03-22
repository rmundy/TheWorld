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
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];
                if(String.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email");
                }

                if(this.MailService.SendMail(email,
                    email,
                    $"Contact Page from {cvm.Name} ({cvm.Email})",
                    cvm.Message))
                {
                    ModelState.Clear();

                    ViewBag.Message = "Mail Sent.  Thanks!";
                } 
            }
            return View();
        }
    }
}