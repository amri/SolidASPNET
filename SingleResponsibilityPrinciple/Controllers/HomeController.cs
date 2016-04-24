using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SingleResponsibilityPrinciple.Core;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SingleResponsibilityPrinciple.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public List<Customer> GetData(string criteria, string searchby)
        {
            List<Customer> customers = null;
            switch (searchby)
            {
                case "companyname":
                    customers = CustomerSearch.SearchByCompanyName(criteria);
                    break;
                case "contactname":
                    customers = CustomerSearch.SearchByContactName(criteria);
                    break;
                case "country":
                    customers = CustomerSearch.SearchByCountry(criteria);
                    break;
            }
            return customers;
        }

        [HttpPost]
        public IActionResult Search(string criteria, string searchby)
        {
            var model = GetData(criteria, searchby);
            ViewBag.Criteria = criteria;
            ViewBag.SearchBy = searchby;
            return View(model);
        }

        [HttpPost]
        public FileResult Export(string criteria, string searchby)
        {
            var data = GetData(criteria, searchby);
            string exportedData = CustomerDataExporter.ExportToCSV(data);
            return File(System.Text.Encoding.ASCII.GetBytes(exportedData), "application/Excel");
        }
    }
}
