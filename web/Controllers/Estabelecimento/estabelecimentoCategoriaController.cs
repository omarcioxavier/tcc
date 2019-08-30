using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Estabelecimento
{
    public class estabelecimentoCategoriaController : Controller
    {
        private DBConn _context;

        public estabelecimentoCategoriaController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// estabelecimentoCategoria/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.estabelecimentosCategorias, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// estabelecimentoCategoria/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.estabelecimentosCategorias.Where(c => c.estabelecimentoCategoriaID == id), JsonRequestBehavior.AllowGet);
        }
    }
}