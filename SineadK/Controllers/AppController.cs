using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SineadK.Models;
using SineadK.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SineadK.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly Data.ISineadRepository _repository;

        public AppController(IMailService mailService, Data.ISineadRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }
          
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(template: "contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            //throw new InvalidOperationException("Oh dear");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
            //send email
                _mailService.SendMessage("sineadmj.kelly@gmail.com", model.Subject, model.Message);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
                
            }
            
             return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();

            return View(results);
        }
    }
}
