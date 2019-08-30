using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Endereco
{
    public class estadoController : Controller
    {
        private DBConn _context;

        public estadoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// estado/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.estados, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// estado/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.estados.Where(e => e.estadoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}