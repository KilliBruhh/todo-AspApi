using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.DTO;
using AspApi.Models;
using AspApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspApi.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {

        private readonly IRepo _repo;
        private readonly IMapper _map;

        public ToDoController(IRepo repo, IMapper map) 
        {
            _repo = repo;
            _map = map;
        }


        [HttpGet]
        public ActionResult GetAllTodo()
        {
            return Ok(_map.Map<IEnumerable<TodoReadDto>>(
                _repo.GetAllTodo()
            ));
        } 

        [HttpGet("{id}")]
        public ActionResult GetTodoById(int id)
        {
            return Ok(_map.Map<IEnumerable<TodoReadDto>>(
                _repo.GetTodoById(id)
            ));
        }

        [HttpPost]
        public ActionResult AddTodo(TodoWriteDto t) {
            var todo = _map.Map<Todo>(t);
            _repo.AddTodo(todo);
            _repo.SaveChanges();
            return Ok(); // Succes?? --> 200 OK
        }

    }
}