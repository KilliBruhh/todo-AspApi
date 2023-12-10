using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspApi.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {

        List<Todo> todolist = new List<Todo>();

        public ToDoController() 
        {
            todolist.Add(new Todo(){Id=1,Title="Bakker",DueDate = new DateTime(2023, 12, 4), Priority=1});
            todolist.Add(new Todo(){Id=1,Title="Brouwer",DueDate = new DateTime(2023, 12, 3), Priority=2});
            todolist.Add(new Todo(){Id=1,Title="Monique",DueDate = new DateTime(2023, 12, 2), Priority=4});
            todolist.Add(new Todo(){Id=1,Title="Sjotten",DueDate = new DateTime(2023, 12, 1), Priority=5});
        }


        [HttpGet]
        public ActionResult GetAllTodo()
        {
            return Ok(todolist);            // Methot exists in ContollerBase class
        } 

        [HttpPost]
        public ActionResult GetTodoById()
        {
            return Ok("Post");
        }
    }
}