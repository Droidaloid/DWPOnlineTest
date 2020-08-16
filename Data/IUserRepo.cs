using System.Collections.Generic;
using DWPOnlineTest.Models;

namespace DWPOnlineTest.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUsersByCity(string city);
    }
}