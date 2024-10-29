using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Objetos
{
    public class ContasList<T>
    {
        public List<T> ContasLista { get; set; }

        public ContasList()
        {
            ContasLista = new List<T>();
        }
    }
    public class ContasPost : Contas
    {
        public int Id { get; set; }
    }
    public class Contas
    {
        public double Valor { get; set; }
        public string Titulo { get; set; }
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
    }

    public class ContasModel
    {
        static List<Contas> conta = new List<Contas>();
        public List<Contas> Conta { get { return conta; } set { conta = value; } }
        public ContasModel() { }

        public void AddConta(Contas contasobj)
        {
            conta.Add(contasobj);
        }
        public ContasPost BuscarConta(int id)
        {
            ContasPost contaobj = new ContasPost();
            DataBase.ColetarDados(id);

            return contaobj;
        }
        public void Delete(int id)
        {
           
        }
        public void Atualiza(Contas obj,int id)
        {
           
        }
    }
}
