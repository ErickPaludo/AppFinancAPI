using Microsoft.AspNetCore.Mvc;
using WebApplication1.Objetos;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GastosController : ControllerBase
    {
        ContasModel contas = new ContasModel();
        [HttpPost("EnvioContas")]
        public IActionResult EnvioContas([FromBody] ContasList<Contas> contasobj)
        {

            string tipo = string.Empty;
            string msg = string.Empty;
            var response = new Response<ResPonseList>();
            foreach (var obj in contasobj.ContasLista)
            {
                try
                {
                    contas.AddConta(obj);
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
        public IActionResult AtualizaContas([FromBody] ContasPost contasobj)
        {
            contas.Atualiza(contasobj);
            return Ok();
        }

        [HttpDelete("DeleteContas")]
        public IActionResult DeleteContas(int id)
        {
            contas.Delete(id);
            return Ok();
        }

        [HttpGet("ReturnContas")]
        public IActionResult RetornoContas(int id)
        {
            var responseConta = new ContasList<ContasPost>();
            try
            {
                if (id == 0)
                {
                    foreach (var obj in contas.Conta)
                    {
                        responseConta.ContasLista.Add(new ContasPost
                        {
                            Id = obj.Key,
                            Titulo = obj.Value.Titulo,
                            Valor = obj.Value.Valor,
                            Tipo = obj.Value.Tipo,
                            Data = obj.Value.Data
                        });
                    }
                }
                else
                {
                    var obj = contas.BuscarConta(id);
                    responseConta.ContasLista.Add(obj);
                }
                return Ok(responseConta);
            }
            catch (Exception ex)
            {
                var response = new Response<ResPonseList>();

                response.response.Add(new ResPonseList
                {
                    code = 400,
                    desc = ex.Message
                });

                return Ok(response);
            }
        }
    }
}
