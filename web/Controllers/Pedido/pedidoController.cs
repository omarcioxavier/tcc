using System;
using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;
using web.ViewModel.Pedido;

namespace web.Controllers.Pedido
{
    public class pedidoController : Controller
    {
        private DBConn _context;

        public pedidoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// Listar os pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult listar(int? id)
        {
            try
            {
                // Obtém o ID do estabelecimento
                var estabelecimentoId = int.Parse(Session["EstabelecimentoId"].ToString());


                // Obtém os pedidos do estabelecimento
                var pedidos = _context.pedidos.Where(p => p.estabelecimentoID == estabelecimentoId);

                // Se clienteID != null, filtra por cliente
                if (id != null)
                {
                    pedidos = pedidos.Where(p => p.clienteID == id);
                }

                foreach (var pedido in pedidos)
                {
                    pedido.cliente = _context.clientes.Where(c => c.clienteID == pedido.clienteID).SingleOrDefault();
                }

                return View(pedidos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult detalhes(int id)
        {
            try
            {
                // Obtém os pedidos do estabelecimento
                var pedido = _context.pedidos.Where(p => p.pedidoID == id).SingleOrDefault();

                // Obtém o cliente do pedido
                pedido.cliente = _context.clientes.Where(c => c.clienteID == pedido.clienteID).SingleOrDefault();


                // Obtém o endereço do cliente
                string enderecoCompleto = "-";

                if (pedido.entrega)
                {
                    var clienteEndereco = _context.clientesEnderecos.Where(ce => ce.clienteID == pedido.clienteID).SingleOrDefault();
                    var endereco = _context.enderecos.Where(e => e.enderecoID == clienteEndereco.enderecoID).SingleOrDefault();
                    var cidade = _context.cidades.Where(c => c.cidadeID == endereco.cidadeID).SingleOrDefault();
                    var estado = _context.estados.Where(e => e.estadoID == cidade.estadoID).SingleOrDefault();

                    enderecoCompleto = string.Concat(endereco.logradouro, ", ", endereco.numero, ", ", endereco.bairro, ", ", cidade.nome, "-", estado.uf);
                }

                var viewModel = new pedidoDetalhesViewModel()
                {
                    pedido = pedido,
                    cliente = pedido.cliente,
                    endereco = enderecoCompleto
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}