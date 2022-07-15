using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email, string password);
    }
}
