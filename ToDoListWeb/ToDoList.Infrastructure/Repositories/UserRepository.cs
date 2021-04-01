using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Repository.Base;

namespace ToDoList.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseProjectContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> AddUser(User user)
        {
            return await AddAsync(user);
        }
    }
}
