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
        static Dictionary<int, Contas> conta = new Dictionary<int, Contas>();
        public Dictionary<int, Contas> Conta { get { return conta; } set { conta = value; } }
        public ContasModel() { }

        public void AddConta(Contas contasobj)
        {
            conta.Add(conta.Count + 1, contasobj);
        }
        public ContasPost BuscarConta(int id)
        {
            ContasPost contaobj = new ContasPost();
            foreach (var obj in conta)
            {
                if (obj.Key == id)
                {
                    contaobj = new ContasPost { Id = obj.Key,Valor = obj.Value.Valor,Titulo = obj.Value.Titulo, Tipo = obj.Value.Tipo,Data = obj.Value.Data };
                    break;
                }
            }

            return contaobj;
        }
        public void Delete(int id)
        {
            conta.Remove(id);
        }
        public void Atualiza(Contas obj,int id)
        {
            if (conta.ContainsKey(id))
            {
                conta[id] = obj;
            }
        }
    }
}
