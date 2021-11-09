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

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeView());

            EmployeeView model = _employeesService.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView model)
        {
            if (model.Id > 0)
            {
                var employee = _employeesService.GetById(model.Id);

                if (ReferenceEquals(employee, null))
                    return NotFound();

                employee.FirstName = model.FirstName;
                employee.SurName = model.SurName;
                employee.Age = model.Age;
                employee.Patronymic = model.Patronymic;
                employee.Position = model.Position;
            }
            else
            {
                _employeesService.AddNew(model);
            }
            _employeesService.Commit();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _employeesService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
