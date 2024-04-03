using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EaseTrail.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        [HttpGet]
        public string Metadata()
        {
            return $"{DateTime.Now} - Working";
        }
    }
}
