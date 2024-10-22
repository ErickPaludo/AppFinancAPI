namespace WebApplication1.Objetos
{
    public class ContasList
    {
        public List<Contas> ContasLista { get; set; }
    }
    public class Contas
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public int tipo { get; set; }
        public DateTime Data { get; set; }

        static Dictionary<int, Contas> conta = new Dictionary<int, Contas>();
        public Dictionary<int, Contas> Conta { get { return conta; } set { conta = value; } }
        public Contas() { }

        public void AddConta(Contas contasobj)
        {
            conta.Add(conta.Count + 1, contasobj);
        }
    }
}
