using System.ComponentModel.DataAnnotations;

namespace Asp.Net.Core.Web.Api.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
