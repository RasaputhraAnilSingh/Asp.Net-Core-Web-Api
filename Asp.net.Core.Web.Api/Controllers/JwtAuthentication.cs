using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
namespace Asp.net.Core.Web.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [EnableCors]
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
        [Route("getSecretKey")]
        [HttpGet]
        public ActionResult getSecretKey()
        {
            string? value = _configuration.GetValue<string>("JwtSecret");          
            if (value == null)
            {
                _logger.LogWarning("key is not availabele");
            }
            object result = new { Key = value };
            return Ok(result);
        }
    }
}
