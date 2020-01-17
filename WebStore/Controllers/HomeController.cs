using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly List<EmployeeView> _employeeViews = new List<EmployeeView>
        {
            new EmployeeView
            {
                Id  = 1,
                FirstName = "Jack",
                SurName = "James",
                Patronymic = "Jeelenhole",
                Age = 22,
                Position = "Headhunter"
            },
            new EmployeeView
            {
                Id  = 2,
                FirstName = "Bob",
                SurName = "Bubles",
                Patronymic = "Bet",
                Age = 35,
                Position = "Tracktirshik"
            },
        };

        // GET: /<controller>/
        // GET: /
        // GET: /home/
        // GET: /home/index
        public IActionResult Index()
        {
            //return Content("Hello from controller");
            return View(_employeeViews);
        }
    }
}
