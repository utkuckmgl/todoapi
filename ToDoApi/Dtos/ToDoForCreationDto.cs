using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Dtos
{
    public class ToDoForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public DateTime Deadline { get; set; }
        public int StatuId { get; set; }

        public ICollection<SubToDo> SubToDo { get; set; }


    }


}
