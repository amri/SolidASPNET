using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Core;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = AppSettings.Title;
            using (var db = new AppDbContext())
            {
                var query = from c in db.Contacts
                    orderby c.Id ascending
                    select c;

                var contacts = query.ToList();
                return View(contacts);
            }
        }

        public IActionResult AddContact()
        {
            return View($"AddContact");
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AppDbContext())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    ViewBag.Message = "Contact added successfully";

                }
            }
            return View(contact);
        }

        public IActionResult DeleteContact(int id)
        {
            using (var db = new AppDbContext())
            {
                var contact = (from c in db.Contacts
                    where c.Id == id
                    select c).SingleOrDefault();
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return Redirect("Index");
            }
        }
    }
}
