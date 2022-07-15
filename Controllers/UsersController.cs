using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using dot_bioskop.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace dot_bioskop.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersData _usersData;
        private readonly ILogger _logger;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public UsersController(ILogger<UsersController> logger, IUsersData usersData, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _usersData = usersData;
            _logger = logger;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
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

        [Authorize(Roles = "1")]
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

        [AllowAnonymous]
        [HttpPost("/apiNew/login/")]
        public IActionResult LoginUser(logins login)
        {
            var existingUser = _usersData.LoginUser(login);

            if (existingUser != null)
            {
                var token = jwtAuthenticationManager.Authenticate(login.email, login.password);
                if (token == null)
                    return Unauthorized();
                return Ok(token);
                _logger.LogInformation("Log login available user data (" + login + ")");
                return Ok("Selamat Datang Kembali");
            }
            else
            {
                _logger.LogInformation("Log login unavailable user data (" + login + ")");
                return NotFound("Email/Password Salah");
            }
        }

        [HttpPost("/apiNew/users")]
        public IActionResult AddUser(users user)
        {
            UsersValidation Obj = new UsersValidation();
            if (EmailValidation(user.email) == true)
            {
                user.created_at = DateTime.Now;
                if (user.password == null)
                {
                    user.password = CreateRandomPassword(8);
                    ValidationResult Result = Obj.Validate(user);
                    if (Result.IsValid)
                    {
                        _logger.LogInformation("Log adding user data");
                        _usersData.AddUser(user);
                        return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.id, user);
                    }
                    else
                    {
                        return BadRequest(Result);
                    }
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
                return Ok("User berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable user data (" + id + ")");
                return NotFound("User tidak diketemukan");
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
                return NotFound("User tidak diketemukan");
            }
        }
    }
}