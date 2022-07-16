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
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading;
using System.Diagnostics;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersData _usersData;
        private readonly ILogger _logger;
        //private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly ICustomAuthenticationManager customAuthenticationManager;

        public UsersController(ILogger<UsersController> logger, IUsersData usersData, 
            //IJwtAuthenticationManager jwtAuthenticationManager,
            ICustomAuthenticationManager customAuthenticationManager
            )
        {
            _usersData = usersData;
            _logger = logger;
            //this.jwtAuthenticationManager = jwtAuthenticationManager;
            this.customAuthenticationManager = customAuthenticationManager;
        }

        public static bool EmailValidation(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

        public static string CreateRandomString(int PasswordLength)
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

        protected void SendEmail(string activation_key, string name, string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("DOT Bioskop", "no-reply@dotbioskop.com"));
            message.To.Add(new MailboxAddress("name", "dotbioskop@gmail.com"));
            message.Subject = "Kode aktivasi akun DOT Bioskop";
            message.Body = new TextPart("plain")
            {
                Text = "Kode aktivasi kamu adalah " + activation_key,
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mailtrap.io", 587, false);
                client.Authenticate("0753715d51fde8", "1871ec7f3824a5");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("/apiNew/users")]
        public IActionResult GetUsers()
        {
            _logger.LogInformation("Log accessing all users data");
            return Ok(_usersData.GetUsers());
        }

        [AllowAnonymous]
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
        [HttpPost("/api/login/")]
        public IActionResult LoginUser(logins login)
        {
            var existingUser = _usersData.LoginUser(login);

            if (existingUser != null)
            {
                //var token = jwtAuthenticationManager.Authenticate(login.email, login.password, existingUser.is_admin.ToString());
                string is_admin = existingUser.is_admin.ToString();
                var token = customAuthenticationManager.Authenticate(login.email, is_admin);
                if (token == null)
                    return Unauthorized();
                _logger.LogInformation("Log login available user data (" + login + ")");
                return Ok(token);
            }
            else
            {
                _logger.LogInformation("Log login unavailable user data (" + login + ")");
                return NotFound("Email/Password Salah");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost("/apiNew/users")]
        public IActionResult AddUser(users user)
        {
            UsersValidation Obj = new UsersValidation();
            if (EmailValidation(user.email) == true)
            {
                user.created_at = DateTime.Now;
                user.activation_key = CreateRandomString(12);
                _logger.LogInformation("Log adding user data");
                _usersData.AddUser(user);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("DOT Bioskop", "no-reply@dotbioskop.com"));
                message.To.Add(new MailboxAddress(user.name, user.email));
                message.Subject = "Kode aktivasi akun DOT Bioskop";
                message.Body = new TextPart("plain")
                {
                    Text = "Kode aktivasi kamu adalah " + user.activation_key,
                };
                using (var client = new SmtpClient())
                    {
                    client.Connect("smtp.mailtrap.io", 587, false);
                    client.Authenticate("0753715d51fde8", "1871ec7f3824a5");

                    client.Send(message);
                    client.Disconnect(true);
                }
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.id, user);

            }
            else
            {
                return NotFound("Email tidak valid");
            }
        }

        [AllowAnonymous]
        [HttpPost("/api/activationuser")]
        public IActionResult ActivationUser(logins user)
        {
            UsersValidation Obj = new UsersValidation();
            if (EmailValidation(user.email) == true)
            {
                _logger.LogInformation("Log activating user data ("+ user.email +")");
                var result = _usersData.ActivationUser1(user);
                if (result != null)
                {
                    _usersData.ActivationUser2(user);
                    return Ok("Akun sudah teraktivasi");
                }
                else
                {
                    return Ok("Email/Password/Kode aktivasi salah");
                }
            }
            else
            {
                return BadRequest("Email tidak valid");
            }
        }

        [AllowAnonymous]
        [HttpPost("/api/users")]
        public IActionResult RegisterUser(users user)
        {
            UsersValidation Obj = new UsersValidation();
            if (EmailValidation(user.email) == true)
            {

                user.created_at = DateTime.Now;
                var activation_key = CreateRandomString(12);
                user.activation_key = activation_key;
                user.is_confirmed = 0;
                ValidationResult Result = Obj.Validate(user);
                if (Result.IsValid)
                {
                    Thread t1 = new Thread(() => SendEmail(activation_key, user.name, user.email));

                    t1.Start();

                    _logger.LogInformation("log registering user data");
                    _usersData.AddUser(user);

                    return Ok("Silakan cek email kamu " + user.email);
                }
                else
                {
                    return BadRequest(Result);
                }
            }
            else
            {
                return NotFound("Email tidak valid");
            }
        }

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
        [HttpPatch("/api/users/{id}")]
        public IActionResult SoftDeleteUser(int id)
        {
            var existingUser = _usersData.GetUser(id);

            if (existingUser != null)
            {
                existingUser.deleted_at = DateTime.Now;
                _logger.LogInformation("Log deleting available user data ("+id+")");
                _usersData.SoftDeleteUser(existingUser);
                return Ok("User berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable user data (" + id + ")");
                return NotFound("User tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
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