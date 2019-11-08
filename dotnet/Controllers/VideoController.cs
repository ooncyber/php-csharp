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
            enviar(@"arquivos\001 Introduc227o.mp4");
            return Ok("ok");
        }

        public string _pathFinal = "";

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
            file.CopyToAsync(fileStream);
            _pathFinal = pathFinal;
            fileStream.Close();
            enviar(pathFinal);
            return Ok(new {resultado = "OK", file= pathFinal});


        }

        public void enviar(string path){
            WebClient c = new WebClient();
            WebProxy p = new WebProxy("172.16.0.1",true);
            p.Credentials = new NetworkCredential("2840481821010", "block");
            WebRequest.DefaultWebProxy = p;
            byte[] rawResponse = c.UploadFile("http://localhost", path);
            Console.WriteLine("Remote Response: {0}", System.Text.Encoding.ASCII.GetString(rawResponse));
            System.IO.File.Delete(path);

        }
    }
}