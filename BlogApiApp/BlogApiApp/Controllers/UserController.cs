using BlogApiApp.Model;
using BlogApiApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BlogApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IRepository<User> repository;
        private IConfiguration? _config;

        public UserController(IRepository<User> repo, IConfiguration configuration)
        {
            repository = repo;
            _config = configuration;
        }
        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(_config["JWT:Issuer"], _config["JWT:Audience"], null,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
        private async Task<IActionResult> UserAuthentication(string UserName, string Password)
        {
            List<User> userList = await repository.GetAll();
            var user = userList.Find(s => s.Email == UserName & s.Password == Password);
            if (user != null)
            {
                var token = GenerateToken();
                return Ok(new { token = token, username = user.UserName, userId = user.UserId, userEmail = user.Email });
            }
            return NotFound(new { message = "Invalid Credentials" });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("UserLogin")]
        public async Task<IActionResult> UserLogin(User user)
        {
            return await UserAuthentication(user.Email, user.Password);

        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await repository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var lstUser = await repository.Get(id);
            if (lstUser == null)
            {
                return NotFound();
            }
            return lstUser;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult<User>> delete(int id)

        {

            var user = await repository.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult<User>> update(User user)
        {
            var result = await repository.Update(user);
            return CreatedAtAction("Get", new { id = result.UserId });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<User>> Post(User user)
        {
            var result = await repository.Add(user);
            return CreatedAtAction("Get", new { id = result.UserId });
        }
    }
}