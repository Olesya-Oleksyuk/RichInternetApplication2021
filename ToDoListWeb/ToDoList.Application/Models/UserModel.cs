using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Application.Models
{
    class UserModel
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
