using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext context;

        public CommentController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return context.Comments;
        }

        [HttpGet("{Id}")]
        public Comment Get(int Id)
        {
            try
            {
                return context.Comments.Find(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public Comment Post([FromBody] Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var comment = context.Comments.Find(Id);
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
