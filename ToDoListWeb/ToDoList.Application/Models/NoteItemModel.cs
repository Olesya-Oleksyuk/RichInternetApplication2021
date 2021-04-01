using System;
using System.Collections.Generic;
using System.Text;
using static ToDoList.CommonData.CommonData;

namespace ToDoList.Application.Models
{
    class NoteItemModel
    {
        public NoteItemModel()
        {
        }

        public DateTime DateCreated { get; set; }
        public string NoteContent { get; set; }
        public string NoteDescription { get; set; }
        public int NoteIndex { get; set; }
        public StatusType Status { get; set; }
        public Guid NoteId { get; set; }


    }
}
