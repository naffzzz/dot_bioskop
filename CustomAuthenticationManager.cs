using System;
using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Models;
using System.Threading.Tasks;
using dot_bioskop.Interfaces;

namespace dot_bioskop
{
    public interface ICustomAuthenticationManager
    {
        string Authenticate(string email, string is_admin);

        IDictionary<string, Tuple<string, string>> Tokens { get; }
    }

    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {

        private readonly IDictionary<string, Tuple<string, string>> tokens = 
            new Dictionary<string, Tuple<string, string>>();

        public IDictionary<string, Tuple<string, string>> Tokens => tokens;

        public string Authenticate(string email, string is_admin)
        {

            var token = Guid.NewGuid().ToString();

            tokens.Add(token, new Tuple<string, string>(email, is_admin));

            return token;
        }
    }
}
