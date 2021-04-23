using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Employees
    {
        public string result  { get; set; }
        public Employees() { }
        
        public void getInformation(string name, string surnames, string ci, string city, string country)
        {
            result = string.Format("Employees Name: {0} SurName: {1}, CI: {2}, City: {3}, Country: {4} ",
                name, surnames, ci, city, country);
            
        }
    }
}
