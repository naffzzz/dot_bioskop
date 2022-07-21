using System;
using System.Collections.Generic;

namespace dot_bioskop.Interfaces
{
    public interface ICustomAuthenticationManager
    {
        string Authenticate(string email, string is_admin);

        IDictionary<string, Tuple<string, string>> Tokens { get; }
    }
}
