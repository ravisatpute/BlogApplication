using BlogApiApp.Model;
using BlogApiApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommnetController : ControllerBase
    {
        private IRepository<Comment> repository;

        public CommnetController(IRepository<Comment> repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAll()
        {
            return await repository.GetAll();
        }
        [HttpGet]
        [Route("GetCommentById")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {

            var commentById = await repository.GetStoreProcedureData(id);
            if (commentById == null)
            {
                return NotFound();
            }
          return Ok(commentById);
         
        }

        [HttpDelete]
        public async Task<ActionResult<Comment>> delete(int id)

        {
            var user = await repository.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPut]
        public async Task<ActionResult<Comment>> update(Comment comment)
        {
            comment.DateTime = DateTime.Now;
            var result = await repository.Update(comment);
            return CreatedAtAction("GetCommentById", new { id = comment.CommentId }, comment);
        }
        [HttpPost]
        [Route("AddComment")]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            comment.DateTime = DateTime.Now;
            var result= await repository.Add(comment);
            return Ok( new { id = result.CommentId , result });
        }
    }
}
