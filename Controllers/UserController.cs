using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DWPOnlineTest.Models;
using DWPOnlineTest.Data;


namespace DWPOnlineTest.Controllers
{
    
    [Route("api/users")]
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
        public ActionResult<User> GetAllUsers()
        {
            var Users = _repository.GetAllUsers();
            return Ok(Users);
            
        }

    }
    


}