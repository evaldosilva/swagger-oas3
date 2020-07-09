using Microsoft.AspNetCore.Mvc;

namespace swagger_oas3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "RED RIBBON 'top secret' INSTRUCTIONS: access the page https://localhost:44334/docs with the login 'dragon' and the password 'ball' to read our API documentation.\nDon't tell Bulma.";
        }
    }
}