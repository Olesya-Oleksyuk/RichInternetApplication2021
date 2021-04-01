using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Repository.Base;
using static ToDoList.CommonData.CommonData;

namespace ToDoList.Infrastructure.Repositories
{
    class NoteItemRepository : Repository<NoteItem>, INoteItemRepository
    {
        public NoteItemRepository(BaseProjectContext dbContext) : base(dbContext)
        {
        }

        public async Task<NoteItem> AddNoteItem(NoteItem noteItem)
        {
            return await AddAsync(noteItem);
        }

        public async Task<List<NoteItem>> FindNoteItems(StatusType Status)
        {
            return await _dbContext.NoteItems.
                Where(s => s.Status.Equals(Status)).ToListAsync();
            /*
              select * from NoteItems 
            where Status like '%@Status%'
             */
        }
    }
}
