using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Asp.net.Core.Web.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    //[Authorize]
    public class JwtAuthentication : ControllerBase
    {
        private IConfiguration _configuration;
        private ILogger<JwtAuthentication> _logger;
        public JwtAuthentication(IConfiguration configuration,ILogger<JwtAuthentication> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        [Route("getJwtSecreteKey")]
        [HttpGet]
        public ActionResult getJwtSecreteKey()
        {
            string? key = _configuration.GetValue<string>("JwtSecret");
            key = null;
            if (key == null)
            {
                _logger.LogWarning("key is not availabele");
            }
            object a = new { Value = key };
            return Ok(a);
        }
    }
}
