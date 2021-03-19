using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Entities.Base;

namespace ToDoList.Core.Entities
{
    public class User:Entity
    {
        public User()
        {

        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
