using System;
using System.Collections.Generic;

namespace dot_bioskop
{
    public class CustomAuthenticationManager
    {

        private static readonly IDictionary<string, Tuple<string, string>> tokens = 
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
