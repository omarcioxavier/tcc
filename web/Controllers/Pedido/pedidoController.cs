using System;
using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

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

                return View(pedidos.OrderByDescending(p => p.dataPedido).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}