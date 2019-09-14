namespace web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cidade",
                c => new
                    {
                        cidadeID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        estadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cidadeID)
                .ForeignKey("dbo.estado", t => t.estadoID, cascadeDelete: false)
                .Index(t => t.estadoID);
            
            CreateTable(
                "dbo.estado",
                c => new
                    {
                        estadoID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        uf = c.String(),
                    })
                .PrimaryKey(t => t.estadoID);
            
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        clienteID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        email = c.String(),
                        numeroCelular = c.String(),
                        ativo = c.Boolean(nullable: false),
                        cllienteCategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.clienteID)
                .ForeignKey("dbo.clienteCategoria", t => t.cllienteCategoriaID, cascadeDelete: false)
                .Index(t => t.cllienteCategoriaID);
            
            CreateTable(
                "dbo.clienteCategoria",
                c => new
                    {
                        clienteCategoriaID = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.clienteCategoriaID);
            
            CreateTable(
                "dbo.clienteEndereco",
                c => new
                    {
                        enderecoClienteID = c.Int(nullable: false, identity: true),
                        clienteID = c.Int(nullable: false),
                        enderecoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.enderecoClienteID)
                .ForeignKey("dbo.cliente", t => t.clienteID, cascadeDelete: false)
                .ForeignKey("dbo.endereco", t => t.enderecoID, cascadeDelete: false)
                .Index(t => t.clienteID)
                .Index(t => t.enderecoID);
            
            CreateTable(
                "dbo.endereco",
                c => new
                    {
                        enderecoID = c.Int(nullable: false, identity: true),
                        logradouro = c.String(),
                        numero = c.String(),
                        complemento = c.String(),
                        bairro = c.String(),
                        cep = c.String(),
                        cidadeID = c.Int(nullable: false),
                        estadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.enderecoID)
                .ForeignKey("dbo.cidade", t => t.cidadeID, cascadeDelete: false)
                .ForeignKey("dbo.estado", t => t.estadoID, cascadeDelete: false)
                .Index(t => t.cidadeID)
                .Index(t => t.estadoID);
            
            CreateTable(
                "dbo.entrega",
                c => new
                    {
                        entregaID = c.Int(nullable: false, identity: true),
                        pedidoID = c.Int(nullable: false),
                        entregaEnderecoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.entregaID)
                .ForeignKey("dbo.entregaEndereco", t => t.entregaEnderecoID, cascadeDelete: false)
                .ForeignKey("dbo.pedido", t => t.pedidoID, cascadeDelete: false)
                .Index(t => t.pedidoID)
                .Index(t => t.entregaEnderecoID);
            
            CreateTable(
                "dbo.entregaEndereco",
                c => new
                    {
                        entregaEnderecoID = c.Int(nullable: false, identity: true),
                        enderecoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.entregaEnderecoID)
                .ForeignKey("dbo.endereco", t => t.enderecoID, cascadeDelete: false)
                .Index(t => t.enderecoID);
            
            CreateTable(
                "dbo.pedido",
                c => new
                    {
                        pedidoID = c.Int(nullable: false, identity: true),
                        dataPedido = c.DateTime(nullable: false),
                        valorPedido = c.Single(nullable: false),
                        entrega = c.Boolean(nullable: false),
                        clienteID = c.Int(nullable: false),
                        estabelecimentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pedidoID)
                .ForeignKey("dbo.cliente", t => t.clienteID, cascadeDelete: false)
                .ForeignKey("dbo.estabelecimento", t => t.estabelecimentoID, cascadeDelete: false)
                .Index(t => t.clienteID)
                .Index(t => t.estabelecimentoID);
            
            CreateTable(
                "dbo.estabelecimento",
                c => new
                    {
                        estabelecimentoID = c.Int(nullable: false, identity: true),
                        razaoSocial = c.String(),
                        nomeFantasia = c.String(),
                        cnpj = c.String(),
                        inscricaoEstadual = c.String(),
                        ativo = c.Boolean(nullable: false),
                        estabelecimentoCategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.estabelecimentoID)
                .ForeignKey("dbo.estabelecimentoCategoria", t => t.estabelecimentoCategoriaID, cascadeDelete: false)
                .Index(t => t.estabelecimentoCategoriaID);
            
            CreateTable(
                "dbo.estabelecimentoCategoria",
                c => new
                    {
                        estabelecimentoCategoriaID = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.estabelecimentoCategoriaID);
            
            CreateTable(
                "dbo.estabelecimentoEndereco",
                c => new
                    {
                        estabelecimentoEnderecoID = c.Int(nullable: false, identity: true),
                        estabelecimentoID = c.Int(nullable: false),
                        enderecoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.estabelecimentoEnderecoID)
                .ForeignKey("dbo.endereco", t => t.enderecoID, cascadeDelete: false)
                .ForeignKey("dbo.estabelecimento", t => t.estabelecimentoID, cascadeDelete: false)
                .Index(t => t.estabelecimentoID)
                .Index(t => t.enderecoID);
            
            CreateTable(
                "dbo.estabelecimentoProduto",
                c => new
                    {
                        estabelecimentoProdutoID = c.Int(nullable: false, identity: true),
                        estabelecimentoID = c.Int(nullable: false),
                        produtoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.estabelecimentoProdutoID)
                .ForeignKey("dbo.estabelecimento", t => t.estabelecimentoID, cascadeDelete: false)
                .ForeignKey("dbo.produto", t => t.produtoID, cascadeDelete: false)
                .Index(t => t.estabelecimentoID)
                .Index(t => t.produtoID);
            
            CreateTable(
                "dbo.produto",
                c => new
                    {
                        produtoID = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        precoUnitario = c.Single(nullable: false),
                        ativo = c.Boolean(nullable: false),
                        produtoCategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.produtoID)
                .ForeignKey("dbo.produtoCategoria", t => t.produtoCategoriaID, cascadeDelete: false)
                .Index(t => t.produtoCategoriaID);
            
            CreateTable(
                "dbo.produtoCategoria",
                c => new
                    {
                        produtoCategoriaID = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.produtoCategoriaID);
            
            CreateTable(
                "dbo.log",
                c => new
                    {
                        logID = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        dataLog = c.DateTime(nullable: false),
                        moduloID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.logID)
                .ForeignKey("dbo.modulo", t => t.moduloID, cascadeDelete: false)
                .Index(t => t.moduloID);
            
            CreateTable(
                "dbo.modulo",
                c => new
                    {
                        moduloID = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.moduloID);
            
            CreateTable(
                "dbo.produtoPedido",
                c => new
                    {
                        produtoPedidoID = c.Int(nullable: false, identity: true),
                        produtoID = c.Int(nullable: false),
                        pedidoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.produtoPedidoID)
                .ForeignKey("dbo.pedido", t => t.pedidoID, cascadeDelete: false)
                .ForeignKey("dbo.produto", t => t.produtoID, cascadeDelete: false)
                .Index(t => t.produtoID)
                .Index(t => t.pedidoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.produtoPedido", "produtoID", "dbo.produto");
            DropForeignKey("dbo.produtoPedido", "pedidoID", "dbo.pedido");
            DropForeignKey("dbo.log", "moduloID", "dbo.modulo");
            DropForeignKey("dbo.estabelecimentoProduto", "produtoID", "dbo.produto");
            DropForeignKey("dbo.produto", "produtoCategoriaID", "dbo.produtoCategoria");
            DropForeignKey("dbo.estabelecimentoProduto", "estabelecimentoID", "dbo.estabelecimento");
            DropForeignKey("dbo.estabelecimentoEndereco", "estabelecimentoID", "dbo.estabelecimento");
            DropForeignKey("dbo.estabelecimentoEndereco", "enderecoID", "dbo.endereco");
            DropForeignKey("dbo.entrega", "pedidoID", "dbo.pedido");
            DropForeignKey("dbo.pedido", "estabelecimentoID", "dbo.estabelecimento");
            DropForeignKey("dbo.estabelecimento", "estabelecimentoCategoriaID", "dbo.estabelecimentoCategoria");
            DropForeignKey("dbo.pedido", "clienteID", "dbo.cliente");
            DropForeignKey("dbo.entrega", "entregaEnderecoID", "dbo.entregaEndereco");
            DropForeignKey("dbo.entregaEndereco", "enderecoID", "dbo.endereco");
            DropForeignKey("dbo.clienteEndereco", "enderecoID", "dbo.endereco");
            DropForeignKey("dbo.endereco", "estadoID", "dbo.estado");
            DropForeignKey("dbo.endereco", "cidadeID", "dbo.cidade");
            DropForeignKey("dbo.clienteEndereco", "clienteID", "dbo.cliente");
            DropForeignKey("dbo.cliente", "cllienteCategoriaID", "dbo.clienteCategoria");
            DropForeignKey("dbo.cidade", "estadoID", "dbo.estado");
            DropIndex("dbo.produtoPedido", new[] { "pedidoID" });
            DropIndex("dbo.produtoPedido", new[] { "produtoID" });
            DropIndex("dbo.log", new[] { "moduloID" });
            DropIndex("dbo.produto", new[] { "produtoCategoriaID" });
            DropIndex("dbo.estabelecimentoProduto", new[] { "produtoID" });
            DropIndex("dbo.estabelecimentoProduto", new[] { "estabelecimentoID" });
            DropIndex("dbo.estabelecimentoEndereco", new[] { "enderecoID" });
            DropIndex("dbo.estabelecimentoEndereco", new[] { "estabelecimentoID" });
            DropIndex("dbo.estabelecimento", new[] { "estabelecimentoCategoriaID" });
            DropIndex("dbo.pedido", new[] { "estabelecimentoID" });
            DropIndex("dbo.pedido", new[] { "clienteID" });
            DropIndex("dbo.entregaEndereco", new[] { "enderecoID" });
            DropIndex("dbo.entrega", new[] { "entregaEnderecoID" });
            DropIndex("dbo.entrega", new[] { "pedidoID" });
            DropIndex("dbo.endereco", new[] { "estadoID" });
            DropIndex("dbo.endereco", new[] { "cidadeID" });
            DropIndex("dbo.clienteEndereco", new[] { "enderecoID" });
            DropIndex("dbo.clienteEndereco", new[] { "clienteID" });
            DropIndex("dbo.cliente", new[] { "cllienteCategoriaID" });
            DropIndex("dbo.cidade", new[] { "estadoID" });
            DropTable("dbo.produtoPedido");
            DropTable("dbo.modulo");
            DropTable("dbo.log");
            DropTable("dbo.produtoCategoria");
            DropTable("dbo.produto");
            DropTable("dbo.estabelecimentoProduto");
            DropTable("dbo.estabelecimentoEndereco");
            DropTable("dbo.estabelecimentoCategoria");
            DropTable("dbo.estabelecimento");
            DropTable("dbo.pedido");
            DropTable("dbo.entregaEndereco");
            DropTable("dbo.entrega");
            DropTable("dbo.endereco");
            DropTable("dbo.clienteEndereco");
            DropTable("dbo.clienteCategoria");
            DropTable("dbo.cliente");
            DropTable("dbo.estado");
            DropTable("dbo.cidade");
        }
    }
}
