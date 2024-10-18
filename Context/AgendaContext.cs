using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Context
{
    public class AgendaContext:DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { }
        public DbSet<Contato> Contatos { get; set; }
    }

}
