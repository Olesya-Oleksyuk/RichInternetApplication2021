using ToDoList.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories;
using ToDoList.Infrastructure.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Infrastructure.Repositories
{
    public class NoteRepository:Repository<Note>,INoteRepository
    {
        public NoteRepository(BaseProjectContext dbContext) : base(dbContext) { }

        public async Task<Note> AddNote(Note Note)
        { 
            return await AddAsync(Note);
        }

        public async Task<List<Note>> FindNotes(string Title)
        {
            return await _dbContext.Notes.
                Where(m => m.Title.ToLower().Contains(Title.ToLower())).
                ToListAsync();
            /*
              select * from Notes 
            where Title like '%@Title%'
             */
        }

    }
}
