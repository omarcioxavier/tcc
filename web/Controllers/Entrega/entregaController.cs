using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Entrega
{
    public class entregaController : Controller
    {
        private DBConn _context;

        public entregaController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// entrega/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.entregas, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// entrega/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.entregas.Where(e => e.entregaID == id), JsonRequestBehavior.AllowGet);
        }
    }
}