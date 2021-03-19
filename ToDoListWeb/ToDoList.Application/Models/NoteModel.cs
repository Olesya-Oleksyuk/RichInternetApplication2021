using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Application.Models.Base;

namespace ToDoList.Application.Models
{
    public class NoteModel:BaseModel
    {
        public NoteModel()
        {
            
        }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }

    }
}
