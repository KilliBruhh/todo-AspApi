using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.DTO;
using AspApi.Models;
using AutoMapper;

namespace AspApi.Mappings
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoWriteDto, Todo>();
        }
    }
}