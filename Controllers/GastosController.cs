using Microsoft.AspNetCore.Mvc;
using WebApplication1.Objetos;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GastosController : ControllerBase
    {
        [HttpPost("EnvioContas")]
        public IActionResult ParametrosHtml([FromBody] ContasList contas)
        {

            string tipo = string.Empty;
            string msg =string.Empty;
            var response = new Response<ResPonseList>();
            foreach (var obj in contas.ContasLista)
            {
                try
                {
                    switch (obj.tipo)
                    {
                        case 1:
                            tipo = "Débito";
                            break;
                        case 2:
                            tipo = "Crédito";
                            break;
                        case 3:
                            tipo = "Vale Refeição";
                            break;
                        default:
                            tipo = "Valor não encontrado";
                            break;
                    }
                    response.response.Add(new ResPonseList
                    {
                        code = 200,
                        desc = "OK"
                    });
                }
                catch (Exception ex)
                {
                    response.response.Add(new ResPonseList
                    {
                        code = 400,
                        desc = ex.Message
                    });
                }
            }
           
            return Ok(response);
        }
    }
}
