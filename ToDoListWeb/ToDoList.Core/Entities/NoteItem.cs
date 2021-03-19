using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Entities.Base;

namespace ToDoList.Core.Entities
{
    enum StatusType { ToDo, InProgess, Completed }

    public class NoteItem : Entity
    {
        public NoteItem()
        {

        }
        public DateTime DateCreated { get; set; }
        public string NoteContent { get; set; }
        public string NoteDescription { get; set; }
        public int NoteIndex { get; set; }
        StatusType Status { get; set; }
        public Guid NoteId { get; set; }
    }
}


