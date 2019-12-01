using System.Data.Entity;
using web.Models.Cliente;
using web.Models.Endereco;
using web.Models.Entrega;
using web.Models.Estabelecimento;
using web.Models.Log;
using web.Models.Pedido;
using web.Models.Produto;
using web.Models.Usuario;
using web.Models.Utils.Modulo;

namespace web.Repository.DBConn
{
    public class DBConn : DbContext
    {
        #region Construtores
        // LOCAL
        //private static string dbName = "tcc_db";

        // CLOUD
        private static string dbName = "DB_A5089E_MarcioXavier";

        public DBConn() : base(dbName)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DBConn Create()
        {
            return new DBConn();
        }
        #endregion

        #region Tabelas
        public DbSet<cliente> clientes { get; set; }

        public DbSet<clienteEndereco> clientesEnderecos { get; set; }

        public DbSet<estabelecimento> estabelecimentos { get; set; }

        public DbSet<estabelecimentoCategoria> estabelecimentosCategorias { get; set; }

        public DbSet<estabelecimentoEndereco> estabelecimentosEnderecos { get; set; }

        public DbSet<estabelecimentoProduto> estabelecimentosProdutos { get; set; }

        public DbSet<endereco> enderecos { get; set; }

        public DbSet<cidade> cidades { get; set; }

        public DbSet<estado> estados { get; set; }

        public DbSet<pedido> pedidos { get; set; }

        public DbSet<produtoPedido> produtosPedidos { get; set; }

        public DbSet<produto> produtos { get; set; }

        public DbSet<produtoCategoria> produtosCategorias { get; set; }

        public DbSet<entrega> entregas { get; set; }

        public DbSet<log> logs { get; set; }

        public DbSet<modulo> modulos { get; set; }

        public DbSet<usuario> usuarios { get; set; }

        public DbSet<pagamento> pagamentos { get; set; }
        #endregion
    }
}