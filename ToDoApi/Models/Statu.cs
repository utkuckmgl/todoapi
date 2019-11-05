using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class Statu
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ToDo> ToDo { get; set; }
        public ICollection<SubToDo> SubToDo { get; set; }


    }
}
