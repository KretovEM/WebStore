using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interface;
using WebStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public IActionResult Index()
        {
            return View(_employeesService.GetAll());
        }

        public IActionResult Details(int id)
        {
            var employee = _employeesService.GetById(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }
    }
}
