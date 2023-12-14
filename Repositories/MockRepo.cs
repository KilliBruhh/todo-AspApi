using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.Models;

namespace AspApi.Repositories
{
    public class MockRepo : IRepo
    {
        List<Todo> todolist = new List<Todo>();

        public MockRepo() 
        {
            todolist.Add(new Todo(){Id=1,Title="Bakker",DueDate = new DateTime(2023, 12, 4), Priority=1});
            todolist.Add(new Todo(){Id=2,Title="Brouwer",DueDate = new DateTime(2023, 12, 3), Priority=2});
            todolist.Add(new Todo(){Id=3,Title="Monique",DueDate = new DateTime(2023, 12, 2), Priority=4});
            todolist.Add(new Todo(){Id=4,Title="Sjotten",DueDate = new DateTime(2023, 12, 1), Priority=5});
        }

        public void AddTodo(Todo t)
        {
            todolist.Add(t);
        }

        public void DeleteTodo(Todo t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAllTodo() {
            return todolist;
        }
        public Todo GetTodoById(int id) {
            Todo _todo = todolist.FirstOrDefault<Todo>(t => t.Id == id);
            return _todo;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTodo(Todo t)
        {
            throw new NotImplementedException();
        }
    }
}