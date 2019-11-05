using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Dtos
{
    public class SubToDoCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ToDo ToDo { get; set; }
        public int ToDoId { get; set; }
    }
}
