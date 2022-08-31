using Microsoft.EntityFrameworkCore;

namespace ConsumerOrcamento
{
    public class ConsumerContext : DbContext
    {


        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Orcamento;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }

        public DbSet<OrcamentoRequest> Orcamento { get; set; }

    }
}
