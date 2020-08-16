using System.Collections.Generic;
using DWPOnlineTest.Models;

namespace DWPOnlineTest.Data
{
    public class UserRepo : IUserRepo
    {
        
        public IEnumerable<User> GetAllUsers()
        {
            RestClient client = new RestClient("https://bpdts-test-app.herokuapp.com/users", httpVerb.GET);
            return client.makeDeserialisedRequest();
        }

        public User GetUserById(int id)
        {
            return new User();

        }

        public User GetUsersByCity(string city)
        {
            return new User();
        }

    }
}