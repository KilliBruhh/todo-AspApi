using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.Models;
using AspApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspApi.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {

        private readonly IRepo _repo;

        public ToDoController(IRepo repo) 
        {
            _repo = repo;
        }


        [HttpGet]
        public ActionResult GetAllTodo()
        {
            return Ok(_repo.GetAllTodo());
        } 

        [HttpGet("{id}")]
        public ActionResult GetTodoById(int id)
        {
            return Ok(_repo.GetTodoById(id));
        }

    }
}