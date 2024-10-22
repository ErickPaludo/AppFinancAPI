using Microsoft.AspNetCore.Mvc;
using WebApplication1.Objetos;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GastosController : ControllerBase
    {
        [HttpPost("EnvioContas")]
        public IActionResult EnvioContas([FromBody] ContasList contas)
        {

            string tipo = string.Empty;
            string msg = string.Empty;
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

        [HttpPut("AtualizaContas")]
        public IActionResult AtualizaContas([FromBody] ContasList contas)
        {

            string tipo = string.Empty;
            string msg = string.Empty;
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

        [HttpDelete("DeleteContas")]
        public IActionResult DeleteContas([FromBody] ContasList contas)
        {

            string tipo = string.Empty;
            string msg = string.Empty;
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

        [HttpGet("ReturnContas")]
        public IActionResult RetornoContas(int id)
        {
            string msg = string.Empty;
            if (id == 0)
            {
                msg = "Deve retornar todos os valores do banco";
            }
            else
            {
                msg = $"Retornará apenas o id {id}";
            }
            var response = new Response<ResPonseList>();

            response.response.Add(new ResPonseList
            {
                code = 400,
                desc = msg
            });

            return Ok(response);
        }
    }
}
