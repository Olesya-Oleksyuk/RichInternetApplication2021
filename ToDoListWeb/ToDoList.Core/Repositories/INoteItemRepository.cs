using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories.Base;
using static ToDoList.CommonData.CommonData;

namespace ToDoList.Core.Repositories
{
    public interface INoteItemRepository: IRepository<NoteItem>
    {
        /// <summary>
        /// Добавление записи to-do листа в БД
        /// </summary>
        /// <param name="noteItem"></param>
        /// <returns></returns>
        Task<NoteItem> AddNoteItem(NoteItem noteItem);

        /// <summary>
        /// Поиск записи todo-листа по статусу
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        Task<List<NoteItem>> FindNoteItems(StatusType Status);
    }

}
