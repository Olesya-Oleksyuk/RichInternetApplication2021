using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Entities.Base;

namespace ToDoList.Core.Entities
{
    public class Note:Entity
    {
        public Note()
        { 

        }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<NoteItem> NoteItems { get; set; } = new List<NoteItem>();
    }
}
