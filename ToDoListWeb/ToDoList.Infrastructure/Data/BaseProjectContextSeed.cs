using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ToDoList.Core.Entities;

namespace ToDoList.Infrastructure.Data
{
    public static class BaseProjectContextSeed
    {
        public static void Migrate(BaseProjectContext context)
        {
            context.Database.Migrate();
        }
        public static void Seed(BaseProjectContext baseProjectContext, int? retry = 0)
        {
            int retryForAvailability = retry.Value; 
            try
            {  
                if (!baseProjectContext.Users.Any())
                {
                    baseProjectContext.Users.AddRange(GetPreconfiguredUsers());
                    baseProjectContext.SaveChanges();
                }
 

            }
            catch
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    Seed(baseProjectContext, retryForAvailability);
                }
                throw;
            }
        }
        /// <summary>
        /// Добавление пользователей
        /// </summary>
        public static IEnumerable<User> GetPreconfiguredUsers()
        {
            byte[] hashPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("qwerty_123"));

            return new List<User>()
            {
               User.Create(Guid.NewGuid(),"Admin","Adminov","admin@mail.ru",hashPassword)
            };
        }
    }
}
