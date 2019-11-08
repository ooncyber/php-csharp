using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using dotnet.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("/video")]
    public class VideoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult Post([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest();

            var arquivoPath = Path.Combine(Directory.GetCurrentDirectory(), "arquivos");

            if (!Directory.Exists(arquivoPath))
                Directory.CreateDirectory(arquivoPath);
            var pathFinal = Path.Combine(arquivoPath, file.FileName);
            FileStream fileStream = new FileStream(pathFinal, FileMode.Create);
            file.CopyTo(fileStream);
            return Ok(new {resultado = "OK", file= pathFinal});

        }

        public void enviar(){
            WebClient c = new WebClient();
            // c.UploadFile("http://localhst:80", arq.FileName);
        }
    }
}