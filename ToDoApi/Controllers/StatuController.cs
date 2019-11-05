using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Dtos;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatuController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public StatuController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Statu>> GetStatus()
        {
            var status = await _dataContext.Status.ToListAsync();
            return status;
        }

        [HttpPost]
        public async Task<IActionResult> AddStatus([FromBody] StatuForCreationDto statuDto)
        {
            //var mystatu = _mapper.Map<Statu>(statuDto);
            var mystatu=new Statu();
            mystatu.Name = statuDto.Name;
            await _dataContext.Status.AddAsync(mystatu);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}