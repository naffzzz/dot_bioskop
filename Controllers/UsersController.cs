using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersData _usersData;
        private readonly ILogger _logger;

        public UsersController(ILogger<UsersController> logger, IUsersData usersData)
        {
            _usersData = usersData;
            _logger = logger;
        }

        public static bool EmailValidation(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        [HttpGet("/apiNew/users")]
        public IActionResult GetUsers()
        {
            _logger.LogInformation("Log accessing all users data");
            return Ok(_usersData.GetUsers());
        }

        [HttpGet("/apiNew/users/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _usersData.GetUser(id);
            if (user != null){
                _logger.LogInformation("Log accessing available specific user data (" + id + ")");
                return Ok(user);
            }
            else
            {
                _logger.LogInformation("Log accessing unavailable specific user data (" + id + ")");
                return NotFound("User tidak diketemukan");
            }
        }

        [HttpPost("/apiNew/users")]
        public IActionResult AddUser(users user)
        {
            if (EmailValidation(user.email) == true)
            {
                user.created_at = DateTime.Now;
                if (user.password == null)
                {
                    user.password = CreateRandomPassword(8);
                    _logger.LogInformation("Log adding user data");
                    _usersData.AddUser(user);
                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.id, user);
                }
                else
                {
                    _logger.LogInformation("Log adding user data");
                    _usersData.AddUser(user);
                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.id, user);
                }
            }
            else
            {
                return NotFound("Email tidak valid");
            }
        }

        [HttpDelete("/apiNew/users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _usersData.GetUser(id);

            if (user != null)
            {
                _logger.LogInformation("Log deleting available user data (" + id + ")");
                _usersData.DeleteUser(user);
                return Ok("User berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable user data (" + id + ")");
                return NotFound("User tidak diketemukan");
            }

        }

        [HttpPatch("/api/users/{id}")]
        public IActionResult SoftDeleteUser(int id, users user)
        {
            var existingUser = _usersData.GetUser(id);

            if (existingUser != null)
            {
                user.deleted_at = DateTime.Now;
                _logger.LogInformation("Log deleting available user data ("+id+")");
                user.id = existingUser.id;
                _usersData.SoftDeleteUser(user);
                return Ok(user);
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable user data (" + id + ")");
                return NotFound("user tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/users/{id}")]
        public IActionResult UpdateUser(int id, users user)
        {
            var existingUser = _usersData.GetUser(id);

            if (existingUser != null)
            {
                user.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available user data (" + id + ")");
                user.id = existingUser.id;
                _usersData.UpdateUser(user);
                return Ok(user);
            }
            else
            {
                _logger.LogInformation("Log updating unavailable user data (" + id + ")");
                return NotFound("user tidak diketemukan");
            }
        }
    }
}