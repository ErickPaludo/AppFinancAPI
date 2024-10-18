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
    }
}
