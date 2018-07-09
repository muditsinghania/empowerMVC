using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empower.Mvc.Models;
using System.Net.Mail;

namespace Empower.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            // new up a contact viewcontroller
            var contact = new ContactViewModel();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel viewModel) {
            if (ModelState.IsValid) {
                //do something
                var message = new MailMessage();
                message.From = new MailAddress("s2empower@gmail.com","SightsourceBOT");
                message.Subject = "New Contact Message";
                message.To.Add(
                    new MailAddress("muditsinghania22@gmail.com"));
                message.Body = $"New contact from{viewModel.Name} ({viewModel.Email})" +
                    Environment.NewLine + viewModel.Message;
                //client smtp new
                var mailClient = new SmtpClient("email-smtp.us-east-1.amazon.com");
                mailClient.EnableSsl = true;
                mailClient.Port = 587;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = new System.Net.NetworkCredential("AKIAJZT46OGOXRVDV55Q", "AnQ9XTmy2Bb7g+adRah8ZLVkJzvwQr3y448eeVfqfGg");
                try {
                    //mailClient.Send(message);
                    viewModel.CompletedAt = DateTime.UtcNow;
                }
                catch(Exception e){
                    viewModel.ErrorMessage = "OOPS! something went wrong";
                }
            }
            return View(viewModel);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
