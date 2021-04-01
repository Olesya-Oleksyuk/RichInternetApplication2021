using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories.Base;

namespace ToDoList.Core.Repositories
{
    public interface INoteRepository : IRepository<Note>
    {
        /// <summary>
        /// Добавление to-do листа в БД
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        Task<Note> AddNote(Note Note);

        /// <summary>
        /// Поиск to-do листа по заголовку 
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        Task<List<Note>> FindNotes(string Title);

    }
}
