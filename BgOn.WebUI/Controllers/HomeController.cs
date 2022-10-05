using BigOn.Domain.AppCode;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace BgOn.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BigOnDbContext db;
        private readonly IConfiguration configuration;

        public HomeController(BigOnDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
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

        public IActionResult Contact(ContactPost model)
        {
            if (ModelState.IsValid)
            {
                db.ContactPosts.Add(model);
                db.SaveChanges();
                var response = new
                {
                    error = false,
                    message = "Muracietiniz qeyde alindi.Tezlikle geri donus edilcek"
                };
                return Json(response);

                //ViewBag.Message = "Muracietiniz qeyde alindi.Tezlikle geri donus edilcek";
                //ModelState.Clear();
                //return View();

            }
            var errorResponse = new
            {
                error = true,
                message = "Melumat uygun deyil duzelis edib yeniden yox",
                state = ModelState.GetErrors()

            };
            return Json(errorResponse);

            //return View(model);
        }
        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Subscribe(Subscribe model)
        {
            if (!ModelState.IsValid)
            {  
                string msg= ModelState.Values.First().Errors[0].ErrorMessage;
                return Json(new
                {
                    error=true,
                    message=msg,
                });
            }

            var entity=db.Subscribes.FirstOrDefault(s=>s.Email.Equals(model.Email));

            if (entity!=null && entity.IsApproved==true)
            {
                return Json(new
                {
                    error = false,
                    message = "Siz artıq abune olmusunuz",
                });
            }

            if (entity==null)
            {
                db.Subscribes.Add(model);
                db.SaveChanges();
            }
            else if (entity!=null)
            {
                model.Id=entity.Id;
            }

            string token = $"{model.Id}-{model.Email}-{Guid.NewGuid()}".Encrypt(Program.key);
            token = HttpUtility.UrlEncode(token);
            string messsage =$"Abuneliyinizi <a href='https://localhost:44304/approve-subscribe?token={token}'>link</a> " +
                "vasitesi ile tesdiq edin";
            configuration.SendMail("aslisg@code.edu.az", messsage, "Subscribe Approve ticket");

            return Json(new
            {
                error = false,
                message = "Emailinize tesdiq mesaji gonderdik"
            });
        }


        // /approve-subscribe?token=21
        [Route("/approve-subscribe")] 
        public string SubscribeApprove(string token)
        {
           token= token.Decrypt(Program.key);
           Match match=  Regex.Match(token, @"^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$");

            if (!match.Success)
            {
                return "token uygun deyil";
            }
            int id = Convert.ToInt32(match.Groups["id"].Value);
            string email = match.Groups["email"].Value;
            string randomKey = match.Groups["randomKey"].Value;
            // ^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$

            var entity = db.Subscribes.FirstOrDefault(s=>s.Id == id);

            if (entity==null)
            {
                return "Tapilmadi";
            }
            if (entity.IsApproved)
            {
                return "Artiq tesdiq edilib";
            }
            entity.IsApproved = true;
            entity.ApprovedData = DateTime.UtcNow.AddHours(4);
            db.SaveChanges();
            return $"id: {id} | Email: {email} | randomKey: {randomKey} ";


        }
    }
}