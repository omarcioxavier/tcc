namespace web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class usuaio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.usuario",
                c => new
                    {
                        usuarioID = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        senha = c.String(),
                        ativo = c.Boolean(nullable: false),
                        estadoSessao = c.Boolean(nullable: false),
                        estabelecimentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usuarioID)
                .ForeignKey("dbo.estabelecimento", t => t.estabelecimentoID, cascadeDelete: false)
                .Index(t => t.estabelecimentoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario", "estabelecimentoID", "dbo.estabelecimento");
            DropIndex("dbo.usuario", new[] { "estabelecimentoID" });
            DropTable("dbo.usuario");
        }
    }
}
