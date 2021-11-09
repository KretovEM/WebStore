using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interface;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryEmployeesService : IEmployeesService
    {
        private readonly List<EmployeeView> _employeeViews;
        public InMemoryEmployeesService()
        {
            _employeeViews = new List<EmployeeView>
            {
                new EmployeeView
                {
                    Id = 1,
                    FirstName = "Jack",
                    SurName = "James",
                    Patronymic = "Jeelenhole",
                    Age = 22,
                    Position = "Headhunter"
                },
                new EmployeeView
                {
                    Id = 2,
                    FirstName = "Bob",
                    SurName = "Bubles",
                    Patronymic = "Bet",
                    Age = 35,
                    Position = "Tracktirshik"
                }
            };
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employeeViews;
        }

        public EmployeeView GetById(int id)
        {
            return _employeeViews.FirstOrDefault(x => x.Id == id);
        }

        public void Commit()
        {
            // в данной реализации не нужен
        }

        public void AddNew(EmployeeView model)
        {
            model.Id = _employeeViews.Max(x => x.Id) + 1;
            _employeeViews.Add(model);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employeeViews.Remove(employee);
            }
        }
    }
}
