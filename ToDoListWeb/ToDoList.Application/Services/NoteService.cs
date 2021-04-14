using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Mapper;
using ToDoList.Application.Models;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories;

namespace ToDoList.Application.Services
{
    public class NoteService: INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteModel> AddNote(NoteModel NoteModel)
        {
            try
            {
                var mappedModelToEntity= ObjectMapper.Mapper.Map<Note>(NoteModel);
                var data = await _noteRepository.AddNote(mappedModelToEntity);
                return new NoteModel()
                {
                    Result = CommonData.CommonData.Result.ok
                };

            } catch(Exception exp)
            {
                return new NoteModel()
                {
                    Result = CommonData.CommonData.Result.error,
                    Error = exp
                };
            }
        }

        public async Task<List<NoteModel>> GetNotes()
        {
            var data = await _noteRepository.GetNotes();
            List<NoteModel> mappedEntityToModel = new List<NoteModel>();
            foreach (var item in data)
            {
                var noteModel = ObjectMapper.Mapper.Map<NoteModel>(item);
                mappedEntityToModel.Add(noteModel);
            }
            return mappedEntityToModel;
        }
    }
}
