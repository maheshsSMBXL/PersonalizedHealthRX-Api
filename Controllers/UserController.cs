using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalizedHealthRX_Api.Data;

namespace PersonalizedHealthRX_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        [HttpGet("UserData")]
        public async Task<IActionResult> getuserdata()
        {
            var Userdata = _userManager.Users.ToList();
            return Ok(Userdata);
        }
    }
}
