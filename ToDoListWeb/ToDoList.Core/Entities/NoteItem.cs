using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Entities.Base;
using static ToDoList.CommonData.CommonData;

namespace ToDoList.Core.Entities
{
   

    public class NoteItem : Entity
    {
        public NoteItem()
        {
            
        }
        public DateTime DateCreated { get; set; }
        public string NoteContent { get; set; }
        public string NoteDescription { get; set; }
        public int NoteIndex { get; set; }
        public StatusType Status { get; set; }
        public Guid NoteId { get; set; }
        public Note Note { get; set; }

        public static NoteItem Create(DateTime DateCreated, string NoteContent, string NoteDescription, int NoteIndex, StatusType Status, Guid NoteId)
        {
            return new NoteItem()
            {
                DateCreated = DateCreated,
                NoteContent = NoteContent,
                NoteDescription = NoteDescription,
                NoteIndex = NoteIndex,
                Status = Status,
                NoteId = NoteId
            };
        }
    }
}


