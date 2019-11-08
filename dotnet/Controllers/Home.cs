using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("/")]
    public class Home : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            Dictionary<string,string> ar = new Dictionary<string, string>();
            ar.Add("Resultado","OK");
            return Ok(ar);
        }
    }
}