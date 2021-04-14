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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> AddUser(UserModel UserModel)
        {
            try
            {
                var mappedModelToEntity = ObjectMapper.Mapper.Map<User>(UserModel);
                var data = await _userRepository.AddUser(mappedModelToEntity);
                return new UserModel()
                {
                    Result = CommonData.CommonData.Result.ok
                };

            }
            catch (Exception exp)
            {
                return new UserModel()
                {
                    Result = CommonData.CommonData.Result.error,
                    Error = exp
                };
            }
        }
    }
}
