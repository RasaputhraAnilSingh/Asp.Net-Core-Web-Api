using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.IO;
namespace Asp.net.Core.Web.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize]
    public class MyFile : ControllerBase
    {


        private IConfiguration _configuration;
        private ILogger<MyFile> _logger;

        public MyFile(IConfiguration configuration, ILogger<MyFile> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult createFilePath()
        {

            string filePath = "C:\\Users\\AnilSinghRasaputhra\\Desktop\\AnilSinghR";
            string fileName = "AnilSingh.txt";
            string fullPath = Path.Combine(filePath, fileName);
            DirectoryInfo directoryInfo = null;
            if (!Directory.Exists(filePath))
            {
                directoryInfo = Directory.CreateDirectory(filePath);

            }
            if (!System.IO.File.Exists(fullPath))
            {
                System.IO.File.Create(fullPath);
            }
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine("hello" + DateTime.Now);
                writer.WriteLine("Hello, this is a new line in the file.");
                writer.WriteLine("You can add more lines as needed.");
            }

            return Ok(directoryInfo);
        }
    }
}
