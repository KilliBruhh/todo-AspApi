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

        public void AddTodo(Todo t)
        {
            _context.Todos.Add(t);
        }
        public void UpdateTodo(Todo t)
        {
               
        }
        public IEnumerable<Todo> GetAllTodo()
        {
            return _context.Todos;
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault<Todo>(t => t.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void DeleteTodo(Todo t)
        {
            _context.Todos.Remove(t);
        }
    }
}