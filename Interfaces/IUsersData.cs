using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface IUsersData
    {
        List<users> GetUsers();

        users GetUser(int id);

        users AddUser(users user);

        users UpdateUser(users user);

        void DeleteUser(users user);
    }
}
