using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Data;
using ToDoApi.Dtos;

namespace ToDoApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            //var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(users);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUser(int id)
        //{
        //    DateTime datetime = DateTime.Now;
        //    var x = datetime.CalculateAge();

        //    var user = await _repo.GetUser(id);
        //    var userToReturn = _mapper.Map<UserForDetailedDto>(user);
        //    return Ok(userToReturn);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        //{
        //    if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //    {
        //        return Unauthorized();
        //    }

        //    var userFromRepo = await _repo.GetUser(id);

        //    _mapper.Map(userForUpdateDto, userFromRepo);

        //    if (await _repo.SaveAll())
        //    {
        //        return NoContent();
        //    }

        //    throw new Exception($"Updateing user {id} failed on save");
        //}
    }


}