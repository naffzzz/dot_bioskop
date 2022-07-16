﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using dot_bioskop.Interfaces;

namespace dot_bioskop
{
    public class JWTAuthenticationManager : IJwtAuthenticationManager
    {
        //IDictionary<string, string> users = new Dictionary<string, string>
        //{
        //    { "test1@gmail.com", "password1" },
        //    { "test2@gmail.com", "password2" }
        //};
 
        private readonly string tokenKey;
 
        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
 
        public string Authenticate(string email, string password)
        {
            //if (!users.Any(u => u.Key == email && u.Value == password))
            //{
            //    return null;
            //}
 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
