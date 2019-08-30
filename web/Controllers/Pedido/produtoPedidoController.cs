using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Pedido
{
    public class produtoPedidoController : Controller
    {
        private DBConn _context;

        public produtoPedidoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// produtoPedido/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.produtosPedidos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// produtoPedido/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.produtosPedidos.Where(l => l.produtoPedidoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}