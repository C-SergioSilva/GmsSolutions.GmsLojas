namespace GmsSolutions.DBreposotorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Contato = c.String(),
                        SobreNome = c.String(),
                        Endereco = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.RlClientVenda",
                c => new
                    {
                        RelacaoCliVenId = c.Int(nullable: false, identity: true),
                        VendaId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelacaoCliVenId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Venda", t => t.VendaId)
                .Index(t => t.VendaId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        NomeProd = c.String(),
                        QdeProduto = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        DataVenda = c.DateTime(nullable: false),
                        FormaPg = c.String(),
                        PgaReceber = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Cliente_ClienteId = c.Int(),
                        Clientes_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId)
                .ForeignKey("dbo.Cliente", t => t.Clientes_ClienteId)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.Clientes_ClienteId);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DescProduto = c.String(),
                        QdeCompra = c.Int(nullable: false),
                        ValorCompra = c.Double(nullable: false),
                        Contato = c.String(),
                        DataCompra = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UltimaCompra = c.DateTime(nullable: false),
                        Estoque = c.Single(nullable: false),
                        Fornecedor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Nome = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RlClientVenda", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.Venda", "Clientes_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Venda", "Cliente_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.RlClientVenda", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Venda", new[] { "Clientes_ClienteId" });
            DropIndex("dbo.Venda", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.RlClientVenda", new[] { "ClienteId" });
            DropIndex("dbo.RlClientVenda", new[] { "VendaId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Venda");
            DropTable("dbo.RlClientVenda");
            DropTable("dbo.Cliente");
        }
    }
}
