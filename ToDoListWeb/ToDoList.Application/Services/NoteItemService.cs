using AutoMapper;
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
    public class NoteItemService : INoteItemService
    {
        private readonly INoteItemRepository _noteItemRepository;

        public NoteItemService(INoteItemRepository noteItemRepository)
        {
            _noteItemRepository = noteItemRepository;
        }

        public async Task<NoteItemModel> AddNoteItem(NoteItemModel NoteItemModel)
        {
            try
            {
                var mappedModelToEntity = ObjectMapper.Mapper.Map<NoteItem>(NoteItemModel);
                var data = await _noteItemRepository.AddNoteItem(mappedModelToEntity);
                return new NoteItemModel()
                {
                    Result = CommonData.CommonData.Result.ok
                };

            }
            catch (Exception exp)
            {
                return new NoteItemModel()
                {
                    Result = CommonData.CommonData.Result.error,
                    Error = exp
                };
            }
        }
    }
}
