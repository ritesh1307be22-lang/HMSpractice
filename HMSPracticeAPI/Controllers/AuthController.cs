using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using HMSPracticeAPI.Models;
using HMSPracticeAPI.Services;

namespace HMSPracticeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMongoCollection<Admin> _admins;

        public AuthController(MongoDbService mongoDbService)
        {
            _admins = mongoDbService.Database.GetCollection<Admin>("Admins");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var admin = await _admins
                    .Find(a => a.Username == request.Username && a.Password == request.Password)
                    .FirstOrDefaultAsync();

                if (admin == null)
                {
                    return Unauthorized(new { message = "Invalid username or password" });
                }

                return Ok(new { message = "Login successful", username = admin.Username });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error", error = ex.Message });
            }
        }
    }
}