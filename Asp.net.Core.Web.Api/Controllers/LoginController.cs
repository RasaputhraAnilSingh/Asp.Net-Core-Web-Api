using Asp.Net.Core.Web.Api.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Asp.Net.Core.Web.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Login(LoginDTO loginDTO)
        {
            LoginResponseDTO loginResponseDTO = new() { UserName = loginDTO.UserName };
            if (loginDTO.UserName == "AnilSingh" && loginDTO.Password == "test@123")
            {
                
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,loginDTO.UserName),
                        new Claim(ClaimTypes.Role,"Admin")
                    }),
                    Expires = DateTime.Now.AddMinutes(30),
                    SigningCredentials = new(new SymmetricSecurityKey(key),SecurityAlgorithms.Aes128CbcHmacSha256)


                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                loginResponseDTO.token = tokenHandler.WriteToken(token); 

            }
            else
            {
                return Ok("Invalid User and Password");
            }
            return Ok(loginResponseDTO);
        }



    }
}
