using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class SubToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ToDo ToDo { get; set; }
        public int ToDoId { get; set; }
        public Statu Statu { get; set; }
        public int StatuId { get; set; }
    }
}
