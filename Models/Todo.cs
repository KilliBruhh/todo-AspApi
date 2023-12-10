using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title {get; set;}
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
    }
}