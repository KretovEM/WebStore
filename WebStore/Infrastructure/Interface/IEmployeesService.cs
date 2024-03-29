﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interface
{
    /// <summary>
    ///     Интерфейс для работы с сотрудниками
    /// </summary>
    public interface IEmployeesService
    {
        /// <summary>
        ///     Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> GetAll();


        /// <summary>
        ///     Получение сотрудника по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmployeeView GetById(int id);

        /// <summary>
        ///     Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        ///     Добавить нового сотрудника
        /// </summary>
        /// <param name="model"></param>
        void AddNew(EmployeeView model);

        /// <summary>
        ///     Удалить сотрудника
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
