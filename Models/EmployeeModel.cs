using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }


        [DisplayName("Employee Name")]
        public string employee_name { get; set; }

        [DisplayName("Employee Salary")]
        public int employee_salary { get; set; }

        [DisplayName("Employee Age")]
        public int employee_age { get; set; }

        public string profile_image { get; set; }

        [DisplayName("Average Age Status")]
        public string statusAge { get; set; }
        
        [DisplayName("Average Salary Status")]
        public string statusSalary { get; set; }
    }
    
}
