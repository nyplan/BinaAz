using BinaAz.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BinaAz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompaniesController : ControllerBase
    {
        private readonly BinaAzDbContext _context;

        public CompaniesController(BinaAzDbContext context)
        {
            _context = context;
        }

        [HttpPost("new")]
        public async Task<IActionResult> New()
        {
            return Ok();
        }
    }
}
