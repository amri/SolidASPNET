using System;
using System.Collections.Generic;
using System.Text;

namespace SingleResponsibilityPrinciple.Core
{
    public class CustomerDataExporter
    {
        public static string ExportToCSV(List<Customer> customers)
        {
            var sb = new StringBuilder();
            foreach (var customer in customers)
            {
                sb.AppendFormat("{0},{1},{2},{3}", customer.Id, customer.CompanyName, customer.ContactName,
                    customer.Country);
                sb.AppendLine();

            }
            return sb.ToString();
        }

        public static string ExportToXML(List<Customer> customers)
        {
            throw new NotImplementedException();

        }

        public static string ExportToPDF(List<Customer> customers)
        {
            throw  new NotImplementedException();
        }
    }
}