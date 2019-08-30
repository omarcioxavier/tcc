using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Produto
{
    public class produtoCategoriaController : Controller
    {
        private DBConn _context;

        public produtoCategoriaController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// produtoCategoria/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.produtosCategorias, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// produtoCategoria/getById
        /// </summary>
        /// <param name="produtoID"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.produtosCategorias.Where(c => c.produtoCategoriaID == id).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}