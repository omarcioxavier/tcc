using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using web.Models.Endereco;
using web.Models.Enums;
using web.Models.Pedido;
using web.ModelsResponse;
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

        #region Métodos View
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

                // Obtém o tipo de pagamento
                var pagamento = _context.pagamentos.Where(p => p.pagamentoID == pedido.pagamentoID).SingleOrDefault();

                var viewModel = new pedidoDetalhesViewModel()
                {
                    pedido = pedido,
                    cliente = pedido.cliente,
                    endereco = endereco,
                    pagamento = pagamento,
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
        #endregion

        #region Métodos Restful
        [HttpPost]
        public bool efetuarPedido(string jsonPedido)
        {
            try
            {
                if (jsonPedido == null)
                {
                    jsonPedido = testJson.json.Replace("'", "\"");
                }

                // Deserializa o json para objeto
                pedidoResponse pedidoRecebido = JsonConvert.DeserializeObject<pedidoResponse>(jsonPedido);

                var pedido = new pedido();
                int quantidade = 0;
                float total = 0;

                // Calcula quantidade de itens e o total
                foreach (var item in pedidoRecebido.itemOrders)
                {
                    quantidade = item.amount;
                    total = item.value * item.amount;
                }

                if (total != pedidoRecebido.total)
                {
                    throw new Exception("Valores totais estão divergentes. Pedido não efetuado.");
                }

                // Monta objeto pedido
                pedido.dataPedido = pedidoRecebido.data;
                pedido.valorPedido = pedidoRecebido.total;
                pedido.entrega = true;
                pedido.clienteID = 1; // Cliente de Teste tem ID 1 no banco
                pedido.estabelecimentoID = pedidoRecebido.restaurante.id;
                pedido.quantidadeTotal = quantidade;
                pedido.pagamentoID = pedidoRecebido.pagamento.Contains("dinheiro") ? (int)enumPagamento.dinheiro : pedidoRecebido.pagamento.Contains("cartao") ? (int)enumPagamento.cartao : (int)enumPagamento.outro;

                // Insere na tabela pedido
                _context.pedidos.Add(pedido);
                _context.SaveChanges();

                // Insere itens
                foreach (var item in pedidoRecebido.itemOrders)
                {
                    var produtoPedido = new produtoPedido();

                    // Monta objeto produtoPedido
                    produtoPedido.produtoID = item.id;
                    produtoPedido.pedidoID = pedido.pedidoID;
                    produtoPedido.quantidade = item.amount;

                    // Insere na tabela produtoPedido
                    _context.produtosPedidos.Add(produtoPedido);
                    _context.SaveChanges();
                }

                // Insere drinks
                foreach (var item in pedidoRecebido.itemDrinks)
                {
                    var produtoPedido = new produtoPedido();

                    // Monta objeto produtoPedido
                    produtoPedido.produtoID = item.id;
                    produtoPedido.pedidoID = pedido.pedidoID;
                    produtoPedido.quantidade = item.amount;

                    // Insere na tabela produtoPedido
                    _context.produtosPedidos.Add(produtoPedido);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion
    }
}