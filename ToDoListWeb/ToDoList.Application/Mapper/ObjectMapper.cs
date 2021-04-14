using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Application.Models;
using ToDoList.Core.Entities;

namespace ToDoList.Application.Mapper
{
	public static class ObjectMapper
	{
		private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				// This line ensures that internal properties are also mapped over.
				cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
				cfg.AddProfile<AspnetRunDtoMapper>();
			});
			var mapper = config.CreateMapper();
			return mapper;
		});
		public static IMapper Mapper => Lazy.Value;
	}
	public class AspnetRunDtoMapper : Profile
	{
		public AspnetRunDtoMapper()
		{
			CreateMap<Note, NoteModel>()
				.ReverseMap();
			CreateMap<NoteItem, NoteItemModel>()
				.ReverseMap();
			CreateMap<User, UserModel>()
				.ReverseMap();
		}
	}
}
