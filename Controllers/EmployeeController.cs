using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
  
        public async Task<ActionResult> Index()
        {
        
            using (WebClient wc = new WebClient())
            {
                
                var json = wc.DownloadString("http://dummy.restapiexample.com/api/v1/employees");
                               
                var data = (JObject)JsonConvert.DeserializeObject(json);
                var result = data["data"];
           
                var obj = result.ToObject<List<EmployeeModel>>().ToArray();
                
                int sumOfAges = 0;
                int sumOfSalary = 0;

                //Average Age
                foreach(var i in obj)
                {
                    sumOfAges += i.employee_age;
                   
                }
                int AverageAge = sumOfAges / obj.Count();

                ViewBag.AverageOfAge = AverageAge;

                //Average Salary
                foreach (var i in obj)
                {
                    sumOfSalary += i.employee_salary;

                }
                int AverageSalary = sumOfSalary / obj.Count();

                ViewBag.AverageOfSalary = AverageSalary;

                //whether the employee is above or below average age
                foreach (var i in obj)
                {
                    var age= i.employee_age;

                    if(age>= AverageAge)
                    {

                        i.statusAge = "Above Average";
                    }
                    else
                    {
                        i.statusAge = "Below Average";
                    }

                }

                //whether the employee is above or below average salary
                foreach (var i in obj)
                {
                    var salary = i.employee_age;

                    if (salary >= AverageSalary)
                    {

                        i.statusSalary = "Above Average";
                    }
                    else
                    {
                        i.statusSalary = "Below Average";
                    }

                }
                return View(obj);
            }
        }

    }
}