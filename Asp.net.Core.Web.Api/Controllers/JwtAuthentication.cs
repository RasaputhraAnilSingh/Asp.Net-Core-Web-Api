using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
namespace Asp.net.Core.Web.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize]
    public class JwtAuthentication : ControllerBase
    {
        
        private IConfiguration _configuration;
        private ILogger<JwtAuthentication> _logger;
        public JwtAuthentication(IConfiguration configuration,ILogger<JwtAuthentication> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        [Route("getList")]
        [HttpGet]
        public ActionResult getList()
        {
            List<string>? values = new List<string>()
                {
                   "Hi",
                   "Hello",
                   "Hey"
                };
            object result = new {Values = values };
            return Ok(result);
        }
    }
}
