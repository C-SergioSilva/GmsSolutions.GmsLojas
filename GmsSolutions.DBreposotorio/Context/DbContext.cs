using GmsSolutions.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GmsSolutions.DBreposotorio.Context
{
    public class LojaContext : DbContext
    {
        public LojaContext() : base("name=DefaultConnection")
        { 

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda>   Vendas   { get; set; }  
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<RlClientVenda> RelacaoClientVendas { get; set; }
        public DbSet<CategoriaPg> CategoriaPgs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)    
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        //  public System.Data.Entity.DbSet<GmsSolutions.Entities.Produto> Produtos { get; set; }
        //  public System.Data.Entity.DbSet<GmsSolutions.Entities.Cliente> Clientes { get; set; }
        //  public System.Data.Entity.DbSet<GmsSolutions.Entities.Usuario> Usuarios { get; set; }
        //  public System.Data.Entity.DbSet<GmsSolutions.Entities.Venda> Vendas { get; set; }
        //  public System.Data.Entity.DbSet<GmsSolutions.Entities.Fornecedor> Fornecedores { get; set; }
        //  public System.Data.Entity.DbSet<GmsSolutions.Entities.RlClientVenda> RlClientVendas { get; set; }
        //  public System.Data.Entity.DbSet<GmsSolutions.Entities.CategoriaPg> CategoriaPgs { get; set; }
    }
}
