using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Estabelecimento
{
    public class estabelecimentoEnderecoController : Controller
    {
        private DBConn _context;

        public estabelecimentoEnderecoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// estabelecimentoEndereco/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.estabelecimentosEnderecos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// estabelecimentoEndereco/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.estabelecimentosEnderecos.Where(e => e.estabelecimentoEnderecoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}