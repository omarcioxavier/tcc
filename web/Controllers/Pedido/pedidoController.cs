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
        /// pedido/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.pedidos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// pedido/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.pedidos.Where(l => l.pedidoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}