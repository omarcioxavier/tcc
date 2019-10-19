using System;
using System.Linq;
using System.Web.Mvc;
using web.Models.Endereco;
using web.Repository.DBConn;
using web.ViewModel.Endereco;

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

        public void salvar(endereco endereco)
        {
            try
            {
                if (endereco.enderecoID > 0)
                {
                    atualizar(endereco);
                }
                else
                {
                    inserir(endereco);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult editar()
        {
            try
            {
                var estabelecimentoID = int.Parse(Session["EstabelecimentoID"].ToString());
                var estabelecimentoEndereco = _context.estabelecimentosEnderecos.Where(ee => ee.estabelecimentoID == estabelecimentoID).FirstOrDefault();


                var viewModel = new enderecoEditarViewModel();
                endereco endereco = new endereco();

                if (estabelecimentoEndereco != null)
                {
                    // Editar 
                    endereco = _context.enderecos.Where(e => e.enderecoID == estabelecimentoEndereco.enderecoID).SingleOrDefault();
                    viewModel.estados = _context.estados.ToList();
                    viewModel.cidades = _context.cidades.Where(c => c.estadoID == endereco.estadoID).ToList();
                }
                else
                {
                    // Novo
                    viewModel.estados = _context.estados.ToList();
                    viewModel.cidades = _context.cidades.Where(c => c.estadoID == 1).ToList();
                }

                viewModel.endereco = endereco;

                return View("form", viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        private void inserir(endereco endereco)
        {

        }

        [HttpPut]
        private void atualizar(endereco endereco)
        {

        }
    }
}