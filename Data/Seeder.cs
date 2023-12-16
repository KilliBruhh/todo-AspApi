using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApi.Context;
using AspApi.Models;
using AutoFixture;

namespace AspApi.Data
{
    public static class Seeder
    {
        public static void Seed(this TodoContext todoContext)
       {
           if (!todoContext.Todos.Any())
           {
               Fixture fixture = new Fixture();
               fixture.Customize<Todo>(product => product.Without(p => p.Id));
               //--- The next two lines add 100 rows to your database
               List<Todo> products = fixture.CreateMany<Todo>(100).ToList();
               todoContext.AddRange(products);
               todoContext.SaveChanges();
          }
       }
    }
}