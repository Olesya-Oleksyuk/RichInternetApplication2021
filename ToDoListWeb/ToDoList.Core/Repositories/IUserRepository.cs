using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories.Base;

namespace ToDoList.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Добавление пользователя в БД
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<User> AddUser(User user);
    }
}
