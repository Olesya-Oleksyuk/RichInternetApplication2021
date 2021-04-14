using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Models;

namespace ToDoList.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> AddUser(UserModel UserModel);
    }
}
