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

        [HttpGet("{id}", Name="GetTodoById")]
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
         
            return CreatedAtRoute(nameof(GetTodoById), new {Id = todo.Id}, todo);
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateTodo(int id, TodoUpdateDto t) {
            var existingTodo = _repo.GetTodoById(id);
            if(existingTodo == null) {
                return NotFound();
            }

            _map.Map(t, existingTodo);
            _repo.UpdateTodo(existingTodo);
            _repo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteTodo(int id) {
            var existingTodo = _repo.GetTodoById(id);
            if(existingTodo == null) {
                return NotFound();
            }

            _repo.DeleteTodo(existingTodo);
            _repo.SaveChanges();

            return Ok();

        }

    }
}