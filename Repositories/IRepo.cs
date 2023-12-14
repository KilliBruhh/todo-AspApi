using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.Models;

namespace AspApi.Repositories
{
    public interface IRepo
    {
        IEnumerable<Todo> GetAllTodo();
        Todo GetTodoById(int id);
        void AddTodo(Todo t);
        void SaveChanges();
        void UpdateTodo(Todo t);
        void DeleteTodo(Todo t);


    }
}