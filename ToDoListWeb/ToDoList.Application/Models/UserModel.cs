using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Application.Models.Base;

namespace ToDoList.Application.Models
{
    public class UserModel: BaseModel
    {
        public UserModel()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
