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
                    DataBase.GravarConta(obj);
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

        [HttpPut("AtualizaContas/{id}")]
        public IActionResult AtualizaContas([FromBody] Contas contasobj,int id)
        {
            DataBase.AtualizaContas(contasobj,id);
            return Ok();
        }

        [HttpDelete("DeleteContas")]
        public IActionResult DeleteContas(int id)
        {
            DataBase.Delete(id);
            return Ok();
        }

        [HttpGet("ReturnContas")]
        public IActionResult RetornoContas(int id)
        {        
            try
            {
                var dados = DataBase.ColetarDados(id);
                return Ok(dados);
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
