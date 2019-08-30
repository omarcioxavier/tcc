using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Estabelecimento
{
    public class estabelecimentoProdutoController : Controller
    {
        private DBConn _context;

        public estabelecimentoProdutoController()
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
            return Json(_context.estabelecimentosProdutos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// estabelecimentoEndereco/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.estabelecimentosProdutos.Where(p => p.estabelecimentoProdutoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}