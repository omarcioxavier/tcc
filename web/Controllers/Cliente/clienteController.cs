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
        /// cliente/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.clientes, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// cliente/getById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.clientes.Where(c => c.clienteID == id), JsonRequestBehavior.AllowGet);
        }
    }
}