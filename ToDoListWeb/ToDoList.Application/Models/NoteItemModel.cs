using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Application.Models.Base;
using static ToDoList.CommonData.CommonData;

namespace ToDoList.Application.Models
{
    public class NoteItemModel: BaseModel
    {
        public NoteItemModel()
        {
        }

        public DateTime DateCreated { get; set; }
        public string NoteContent { get; set; }
        public string NoteDescription { get; set; }
        public int NoteIndex { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public StatusType Status { get; set; }
        public Guid NoteId { get; set; }


    }
}
