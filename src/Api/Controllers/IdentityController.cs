using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IActionResult Get()
        {
            var claims = User.Claims.Select(claim => new
            {
                claim.Type,
                claim.Value,
                claim.ValueType,
                claim.Issuer
            });
            return new JsonResult(claims);
        }
    }
}