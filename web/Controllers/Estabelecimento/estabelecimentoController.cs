using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Estabelecimento
{
    public class estabelecimentoController : Controller
    {
        private DBConn _context;

        public estabelecimentoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// estabelecimento/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.estabelecimentos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// estabelecimento/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.estabelecimentos.Where(e => e.estabelecimentoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}