using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Context
{
    public class TodoContext : DbContext
    {
        
        public TodoContext(DbContextOptions<TodoContext> opt) 
            : base(opt)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }

    }
}