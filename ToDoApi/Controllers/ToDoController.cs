using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Dtos;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ToDoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDo>> GetToDos()
        {
            //var toDos = await _dataContext.ToDos.Include(p => p.SubToDo).ToListAsync();
            var toDos = await _dataContext.ToDos.Include(s => s.SubToDo).ToListAsync();

            return toDos;
        }

        [HttpPost]
        public async Task<IActionResult> AddTodos([FromBody] ToDoForCreationDto toDo)
        {
            var mytoDo = new ToDo();
            mytoDo.Name = toDo.Name;
            mytoDo.StatuId = toDo.StatuId;
            mytoDo.Description = toDo.Description;
            mytoDo.Deadline = DateTime.UtcNow;
            //if(toDo.SubToDo)
            //var eklenecekOlanSubToDo = new SubToDo();
            //eklenecekOlanSubToDo.Name = "xyz";
            //eklenecekOlanSubToDo.Description = "abc";
            //eklenecekOlanSubToDo.StatuId = 1;
            //eklenecekOlanSubToDo.ToDoId = 2;

            //await _dataContext.SubToDos.AddAsync(eklenecekOlanSubToDo);


            await _dataContext.ToDos.AddAsync(mytoDo);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var removeItem = new ToDo();
            removeItem = await _dataContext.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            _dataContext.ToDos.Remove(removeItem);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PutToDo(int id, [FromBody] ToDoForCreationDto toDo)
        {
            var putItem = new ToDo();
            putItem = await _dataContext.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            putItem.Name = toDo.Name;
            putItem.StatuId = toDo.StatuId;
            putItem.Description = toDo.Description;
            putItem.Deadline = DateTime.UtcNow;
            putItem.SubToDo = toDo.SubToDo;
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}