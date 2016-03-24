using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using TheWorldVS.Models;
using TheWorldVS.Services;
using TheWorldVS.ViewModels;

namespace TheWorldVS.Controllers.Web
{
    public class AppController : Controller
    {
        public IMailService MailService { get; private set; }
        public IWorldRepository Repository { get; private set; }

        public AppController(IMailService mailService, IWorldRepository repository)
        {
            this.MailService = mailService;
            this.Repository = repository;
        }
        public IActionResult Index()
        {
            var trips = this.Repository.GetAllTrips();
            
            return View(trips);
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