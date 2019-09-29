using System;
using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

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
                // Obtém o ID do estabelecimento
                var estabelecimentoId = int.Parse(Session["EstabelecimentoId"].ToString());

                // Obtém os IDs dos usuários que fizeram pedidos do estabelecimento
                var clientesIds = _context.pedidos.Where(p => p.estabelecimentoID == estabelecimentoId).Select(p => p.clienteID).ToArray();

                // Obtém os clientes do estabelecimento pelos IDs
                var clientes = _context.clientes.Where(c => clientesIds.Contains(c.clienteID)).OrderBy(c => c.nome).ToList();

                return View(clientes);
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
    }
}