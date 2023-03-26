using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;

        public UsersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.Users;
        }

        [HttpGet("{Id}")]
        public User Get(int Id)
        {
            try
            {
                return context.Users.Find(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public User Post([FromBody] User users)
        {
            
  //  User user = new User();


            context.Users.Add(users);
            context.SaveChanges();
            return users;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var user = context.Users.Find(Id);
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }

}

