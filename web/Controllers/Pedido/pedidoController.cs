using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using web.Models.Endereco;
using web.Models.Pedido;
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
                // Obtém os pedidos do estabelecimento
                var pedidos = getPedidosEstabelecimento(getEstabelecimentoID(), id);
                
                // Filtra pedidos dos últimos 30 dias
                pedidos = pedidos.Where(p => p.dataPedido >= DateTime.Now.AddDays(-30)).ToList();

                var ViewModel = new pedidoListarViewModel()
                {
                    pedidos = pedidos,
                    dataInicio = DateTime.Now.AddDays(-30),
                    dataFim = DateTime.Now
                };

                return View(ViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult detalhes(int id)
        {
            try
            {
                // Obtém os pedidos do estabelecimento
                var pedido = _context.pedidos.Where(p => p.pedidoID == id).SingleOrDefault();

                // Obtém o cliente do pedido
                pedido.cliente = _context.clientes.Where(c => c.clienteID == pedido.clienteID).SingleOrDefault();

                // Obtém o endereço do cliente
                string enderecoCompleto = "";
                endereco endereco = new endereco();

                if (pedido.entrega)
                {
                    var clienteEndereco = _context.clientesEnderecos.Where(ce => ce.clienteID == pedido.clienteID).SingleOrDefault();
                    endereco = _context.enderecos.Where(e => e.enderecoID == clienteEndereco.enderecoID).SingleOrDefault();
                    var cidade = _context.cidades.Where(c => c.cidadeID == endereco.cidadeID).SingleOrDefault();
                    var estado = _context.estados.Where(e => e.estadoID == cidade.estadoID).SingleOrDefault();

                    enderecoCompleto = string.Concat(endereco.logradouro, ", ", endereco.numero, ", ", endereco.bairro, ", ", cidade.nome, "-", estado.uf);
                }

                // Obtém os produtos do pedido
                var produtosPedido = _context.produtosPedidos.Where(pp => pp.pedidoID == pedido.pedidoID).ToList();
                foreach (var produtoPedido in produtosPedido)
                {
                    produtoPedido.produto = _context.produtos.Where(p => p.produtoID == produtoPedido.produtoID).SingleOrDefault();
                }

                var viewModel = new pedidoDetalhesViewModel()
                {
                    pedido = pedido,
                    cliente = pedido.cliente,
                    endereco = endereco,
                    produtosPedidos = produtosPedido,
                    enderecoCompleto = enderecoCompleto
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult pesquisar(pedidoListarViewModel pedidoPesquisa)
        {
            try
            {
                // Obtém os pedidos do estabelecimento
                var pedidos = getPedidosEstabelecimento(getEstabelecimentoID(), null);

                // Filtra pedidos pela data informada
                pedidos = pedidos.Where(p => p.dataPedido >= pedidoPesquisa.dataInicio && p.dataPedido <= pedidoPesquisa.dataFim).ToList();

                var viewModel = new pedidoListarViewModel()
                {
                    pedidos = pedidos,
                    dataInicio = pedidoPesquisa.dataInicio,
                    dataFim = pedidoPesquisa.dataFim
                };

                return View("listar", viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Obtém o id do estabelecimento da session
        private int getEstabelecimentoID()
        {
            return int.Parse(Session["EstabelecimentoId"].ToString());
        }

        private IEnumerable<pedido> getPedidosEstabelecimento(int estabelecimentoID, int? clienteID)
        {
            // Obtém os pedidos do estabelecimento
            var pedidos = _context.pedidos.Where(p => p.estabelecimentoID == estabelecimentoID).ToList();

            // Se clienteID != null, filtra pedidos por cliente
            if (clienteID != null)
            {
                pedidos = pedidos.Where(p => p.clienteID == clienteID).ToList();
            }

            foreach (var pedido in pedidos)
            {
                pedido.cliente = _context.clientes.Where(c => c.clienteID == pedido.clienteID).SingleOrDefault();
            }

            return pedidos;
        }
    }
}