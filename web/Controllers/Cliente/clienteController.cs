using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using web.Models.Cliente;
using web.Repository.DBConn;
using web.ViewModel.Cliente;

namespace web.Controllers.Cliente
{
    public class clienteController : Controller
    {
        private DBConn _context;

        public clienteController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// cliente/listar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult listar()
        {
            try
            {
                // Obtém os clientes do estabelecimento
                var clientes = getClientesEstabelecimento();

                var viemModel = new clienteListarViewModel()
                {
                    clientes = clientes,
                    ativo = true
                }
;
                return View(viemModel);
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
                var cliente = _context.clientes.Where(c => c.clienteID == id).SingleOrDefault();
                return View(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult pesquisar(clienteListarViewModel clientePesquisa)
        {
            try
            {
                // Obtém os clientes do estabelecimento
                var clientes = getClientesEstabelecimento();

                if (clientePesquisa.nome != null)
                {
                    clientes = clientes.Where(c => c.nome.Contains(clientePesquisa.nome)).ToList();
                }

                if (clientePesquisa.celular != null)
                {
                    clientes = clientes.Where(c => c.numeroCelular.Equals(clientePesquisa.celular)).ToList();
                }

                clientes = clientes.Where(c => c.ativo.Equals(clientePesquisa.ativo)).ToList();

                var viewModel = new clienteListarViewModel()
                {
                    clientes = clientes,
                    nome = clientePesquisa.nome,
                    celular = clientePesquisa.celular,
                    ativo = clientePesquisa.ativo
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

        // Obtém os clientes do estabelecimento pelos IDs
        private IEnumerable<cliente> getClientesEstabelecimento()
        {
            var estabelecimentoId = getEstabelecimentoID();
            // Obtém os IDs dos usuários que fizeram pedidos do estabelecimento
            var clientesIds = _context.pedidos.Where(p => p.estabelecimentoID == estabelecimentoId).Select(p => p.clienteID).ToArray();

            // Retorna os pedidos do cliente para o estabelecimento da session
            return _context.clientes.Where(c => clientesIds.Contains(c.clienteID)).OrderBy(c => c.nome).ToList();
        }
    }
}