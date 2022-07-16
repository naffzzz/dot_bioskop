using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Interfaces
{
    interface ICustomAuthenticationManager
    {
        string Authenticate(string email, string is_admin);

        IDictionary<string, string> Tokens { get; set; }
    }
}
