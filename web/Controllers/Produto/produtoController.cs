using System;
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

        public ActionResult listar()
        {
            try
            {
                // Obtém o ID do estabelecimento
                var estabelecimentoId = int.Parse(Session["EstabelecimentoId"].ToString());

                // Obtém os IDs dos produtos do estabelecimento
                var produtosIds = _context.estabelecimentosProdutos.Where(e => e.estabelecimentoID == estabelecimentoId).Select(e => e.produtoID).ToArray();

                // Obtém os produtos do estabelecimento pelos IDs
                var produtos = _context.produtos.Where(p => produtosIds.Contains(p.produtoID)).OrderBy(p => p.descricao).ToList();

                return View(produtos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}