using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial
{
    public class Customer
    {
        public string result  { get; set; }
        public Customer() { }
        public void getInformation(string name, string surnames, string ci, string city, string country)
        {
            result= string.Format("Customers name: {0} surname: {1}, ci: {2}, city: {3}, country: {4} ",
                name, surnames, ci, city, country);
        }
    }
}
