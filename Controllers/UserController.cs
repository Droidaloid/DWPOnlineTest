using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DWPOnlineTest.Models;
using DWPOnlineTest.Data;


namespace DWPOnlineTest.Controllers
{
    
    [Route("api/ChallengeSolution")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepo _repository;

        public UserController(IUserRepo repository) => _repository = repository;

        /* //get api/GetUserWithinRadius/{radius}
        [HttpGet("{radius}")]
        public ActionResult<IEnumerable<User>> GetUserWithinRadius(int radius)
        {

        }
        */

        [HttpGet]
        public ActionResult<User> GetChallengeSolution()
        {

            List<User> challengeSolution = new List<User>();

            //get users who are listed as living in london

            var londonUsers = _repository.GetUsersByCity("London");

            challengeSolution.AddRange(londonUsers);


            //get users who live within 50 miles of london
            
            var users = _repository.GetAllUsers();
            HaversineCalculator calculate = new HaversineCalculator();

            foreach(var user in users)
            {
                if(calculate.distanceFromLondon(user.latitude, user.longitude) <= 50)
                {
                    challengeSolution.Add(user);
                }
            }

            challengeSolution.Sort();


            return Ok(challengeSolution);
        }

        
        [HttpGet("{radius}")]
        public ActionResult<User> GetUsersWithinLondonRadius(int radius)
        {
            var users = _repository.GetAllUsers();
            List<User> usersWithinRadius = new List<User>();
            HaversineCalculator calculate = new HaversineCalculator();

            foreach(var user in users)
            {
                if(calculate.distanceFromLondon(user.latitude, user.longitude) <= radius)
                {
                    usersWithinRadius.Add(user);
                }

            }

            

            return Ok(usersWithinRadius);
            
        }
        

    }
    


}