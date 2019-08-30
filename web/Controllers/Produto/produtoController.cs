using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Produto
{
    public class produtoController : Controller
    {
        private DBConn _context;

        public produtoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// produto/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.produtos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// produto/getById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.produtos.Where(p => p.produtoID == id).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// produto/getByCategoriaId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getByCategoriaId(int id)
        {
            return Json(_context.produtos.Where(p => p.produtoCategoriaID == id).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}