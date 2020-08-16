using System.Collections.Generic;
using DWPOnlineTest.Models;

namespace DWPOnlineTest.Data
{
    public class UserRepo : IUserRepo
    {
        private RestClient client = new RestClient();

        public IEnumerable<User> GetAllUsers()
        {
            client.endPoint = "https://bpdts-test-app.herokuapp.com/users";
            client.httpMethod = httpVerb.GET;

            return client.makeDeserialisedRequestMultiple();
        }

        public User GetUserById(int id)
        {
            client.endPoint = "https://bpdts-test-app.herokuapp.com/user/" + id.ToString();
            client.httpMethod = httpVerb.GET;

            return client.makeDeserialisedRequestSingle();

        }

        public IEnumerable<User> GetUsersByCity(string city)
        {
            client.endPoint = "https://bpdts-test-app.herokuapp.com/city/" + city + "/users";
            client.httpMethod = httpVerb.GET;

            return client.makeDeserialisedRequestMultiple();
        }

    }
}