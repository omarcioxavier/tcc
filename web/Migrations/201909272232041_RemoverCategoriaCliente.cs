namespace web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverCategoriaCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cliente", "clienteCategoriaID", "dbo.clienteCategoria");
            DropIndex("dbo.cliente", new[] { "clienteCategoriaID" });
            DropColumn("dbo.cliente", "clienteCategoriaID");
            DropTable("dbo.clienteCategoria");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.clienteCategoria",
                c => new
                    {
                        clienteCategoriaID = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.clienteCategoriaID);
            
            AddColumn("dbo.cliente", "clienteCategoriaID", c => c.Int(nullable: false));
            CreateIndex("dbo.cliente", "clienteCategoriaID");
            AddForeignKey("dbo.cliente", "clienteCategoriaID", "dbo.clienteCategoria", "clienteCategoriaID", cascadeDelete: true);
        }
    }
}
