using dot_bioskop.DBContexts;
using dot_bioskop.Models;
using dot_bioskop.Services;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersData _usersData;

        public UsersController(IUsersData usersData)
        {
            _usersData = usersData;
        }


        [HttpGet("/apiNew/users")]
        public IActionResult getUsers()
        {
            return Ok(_usersData.GetUsers());
        }

        [HttpGet("/apiNew/users/{id}")]
        public IActionResult getUser(int id)
        {
            var user = _usersData.GetUser(id);
            if (user != null){
                return Ok(user);
            }

            return NotFound("User tidak diketemukan");
        }

        [HttpPost("/apiNew/users")]
        public IActionResult addUser(users user)
        {
            _usersData.AddUser(user);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.id, user);

        }

        [HttpDelete("/apiNew/users/{id}")]
        public IActionResult deleteUser(int id)
        {
            var user = _usersData.GetUser(id);

            if(user != null)
            {
                _usersData.DeleteUser(user);
                return Ok("User berhasil dihapus");
            }

            return NotFound("User tidak diketemukan");
        }

        [HttpPatch("/apiNew/users/{id}")]
        public IActionResult UpdateUsers(int id, users user)
        {
            var existingUser = _usersData.GetUser(id);

            if (existingUser != null)
            {
                user.id = existingUser.id;
                _usersData.UpdateUser(user);
            }
            return Ok(user);
        }
    }
}