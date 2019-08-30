using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Cliente
{
    public class clienteEnderecoController : Controller
    {
        private DBConn _context;

        public clienteEnderecoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// clienteEndereco/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.clientesEnderecos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// clienteEndereco/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.clientesEnderecos.Where(e => e.enderecoClienteID == id), JsonRequestBehavior.AllowGet);
        }
    }
}