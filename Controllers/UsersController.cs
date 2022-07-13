using dot_bioskop.DBContexts;
using dot_bioskop.Models;
using dot_bioskop.Services;
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
        private ILogger _logger;
        private IUsersService _usersService;


        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet("/api/users")]
        public ActionResult<List<users>> GetUsers()
        {
            return _usersService.GetUsers();
        }

        [HttpPost("/api/users")]
        public ActionResult<users> AddUsers(users user)
        {
            _usersService.AddUsers(user);
            return user;
        }

        [HttpPut("/api/users/{id}")]
        public ActionResult<users> UpdateUsers(int id, users user)
        {
            _usersService.UpdateUsers(id, user);
            return user;
        }

        [HttpDelete("/api/users/{id}")]
        public ActionResult<string> DeleteUsers(int id)
        {
            _usersService.DeleteUsers(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}