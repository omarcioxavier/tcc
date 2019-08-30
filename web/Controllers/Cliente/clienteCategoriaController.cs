using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Cliente
{
    public class clienteCategoriaController : Controller
    {
        private DBConn _context;

        public clienteCategoriaController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// clienteCategoria/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.clientesCategorias, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// clienteCategoria/getById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.clientesCategorias.Where(c => c.categoriaClienteID == id), JsonRequestBehavior.AllowGet);
        }
    }
}