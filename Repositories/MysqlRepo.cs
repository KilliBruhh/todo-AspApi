using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.Context;
using AspApi.Models;

namespace AspApi.Repositories
{
    public class MysqlRepo : IRepo
    {

        private readonly TodoContext _context;

        public MysqlRepo(TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<Todo> GetAllTodo()
        {
            return _context.Todos;
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault<Todo>(t => t.Id == id);
        }
    }
}