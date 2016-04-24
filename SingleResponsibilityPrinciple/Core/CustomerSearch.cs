using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleResponsibilityPrinciple.Core
{
    public class CustomerSearch
    {
        public static List<Customer> SearchByCountry(string country)
        {
            using (var db = new AppDbContext())
            {
                var customers = from c in db.Customers where c.Country.Contains(country) select c;

                return customers.ToList();
            }
        }

        public static List<Customer> SearchByCompanyName(string company)
        {
            using (var db = new AppDbContext())
            {
                var customers = from c in db.Customers where c.CompanyName.Contains(company) select c;

                return customers.ToList();
            }
        }

        public static List<Customer> SearchByContactName(string contact)
        {
            using (var db = new AppDbContext())
            {
                var customers = from c in db.Customers where c.ContactName.Contains(contact) select c;

                return customers.ToList();
            }

        }
    }
}