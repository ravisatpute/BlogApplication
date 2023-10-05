using BlogApiApp.Model;
using BlogApiApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private IRepository<Blog> repository;

        public BlogController(IRepository<Blog> repo)
        {
            repository = repo;

        }

        [HttpGet]

        [Route("GetBlog")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlog()
        {

            var result = await repository.GetAll();
            return result.Where(s => s.IsActive == true).ToList();
        }
       
        [HttpGet]
        [Route("GetBlogById")]
        public async Task<ActionResult<Blog>> GetBlogById(int id)
        {
            var lstUser = await repository.Get(id);
            if (lstUser == null)
            {
                return NotFound();
            }
            return lstUser;
        }

        [HttpDelete]
        public async Task<ActionResult<Blog>> delete(int id)

        {
           
                try
                {
                    var blog = await repository.Get(id);
                    if (blog != null)
                    {
                        blog.IsActive = false;
                        //var result = await repository.Update(blog);
                        //return Ok(result);
                        return await repository.Update(blog);
                    }
                }
               catch (Exception ex) {
                    return NoContent();
                }


            return NoContent();

        }
        [HttpPut]
        public async Task<ActionResult<Blog>> update(Blog blog)
        {

            try
            {
                return await repository.Update(blog);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Result not found" });
            }

          
        }
        [HttpPost]
        [Route("AddBlog")]
        public async Task<ActionResult<Blog>> AddBlog(Blog blog)
        {
            try
            {
                blog.DateTime = DateTime.Now;
                blog.IsActive = true;
                var result = await repository.Add(blog);
                return CreatedAtAction ("GetBlog", new {  id = result.BlogId });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "error occured" });
            }

        }
    }
}
