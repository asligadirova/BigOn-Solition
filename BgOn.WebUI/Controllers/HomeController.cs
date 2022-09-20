using BgOn.WebUI.Models.DataContexts;
using BgOn.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BgOn.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BigOnDbContext db;

        public HomeController(BigOnDbContext db)
        {
            this.db = db;
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
                ViewBag.Message = "Muracietiniz qeyde alindi.Tezlikle geri donus edilcek";
                ModelState.Clear();
                return View();
            }
            return View(model);
        }
        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();
                
            return View(data);
        }
    }
}
