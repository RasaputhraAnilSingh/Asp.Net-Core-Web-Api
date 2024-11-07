using Microsoft.AspNetCore.Mvc;
namespace Asp.net.Core.Web.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class JwtAuthentication : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<List<int>> Get()
        {
            List<int> values = new List<int>()
            {
                1,2,3,4,5,6
            };
            return Ok(values);
        }
    }
}
