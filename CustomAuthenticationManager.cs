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
        private readonly IList<logins> login = new List<logins>
        {
            new logins { email =  "test1@gmail.com", password = "password1", is_admin = 1 },
            new logins { email = "test2@gmail.com", password = "password2", is_admin = 0 }
        };

        private readonly IDictionary<string, Tuple<string, string>> tokens = 
            new Dictionary<string, Tuple<string, string>>();

        public IDictionary<string, Tuple<string, string>> Tokens => tokens;

        public string Authenticate(string email, string is_admin)
        {
            /*if (!login.Any(u => u.email == email && u.password == password))
            {
                return null;
            }*/

            var token = Guid.NewGuid().ToString();

            tokens.Add(token, new Tuple<string, string>(email, is_admin));

            return token;
        }
    }
}
