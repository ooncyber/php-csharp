using Microsoft.AspNetCore.Http;

namespace dotnet.Model
{
    public class Video
    {
        public string Nome { get; set; }
        public IFormFile Arquivo { get; set; }
    }
}