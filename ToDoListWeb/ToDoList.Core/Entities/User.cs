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
        public List<Note> Notes { get; set; } = new List<Note>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }

        public static User Create(Guid Id,string FirstName,string LastName,
            string Email,byte[] Password)
        {
            return new User()
            {
                Id = Id,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password
            };
        }
    }
}
