using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Endereco
{
    public class enderecoController : Controller
    {
        private DBConn _context;

        public enderecoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// endereco/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.enderecos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// endereco/getById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.enderecos.Where(e => e.enderecoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}