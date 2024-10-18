using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("casssandra")]
        public IActionResult ObterData()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToLongTimeString()
            };
            return Ok(obj);
        }
        [HttpGet("parametros/{nome}")]
        public IActionResult ParametrosHtml(string nome)
        {
            string msg = $"Meu pau na mão do(a){nome}";
            return Ok(new {msg});
        }
    }
}
