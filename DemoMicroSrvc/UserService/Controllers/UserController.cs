using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Database;
using UserService.Database.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        DatabaseContext db;
        public UserController()
        {
            db = new DatabaseContext();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
        }

     
    }
}
