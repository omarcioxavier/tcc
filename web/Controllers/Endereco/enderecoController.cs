using System;
using System.Linq;
using System.Web.Mvc;
using web.Models.Endereco;
using web.Models.Estabelecimento;
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

        public ActionResult salvar(endereco endereco)
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
                
                return editar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        private void inserir(endereco endereco)
        {
            // Insere na tabela endereço
            _context.enderecos.Add(endereco);
            _context.SaveChanges();

            // Insere na tabela enderecoEstabelecimento
            var estabelecimentoEndereco = new estabelecimentoEndereco()
            {
                estabelecimentoID = int.Parse(Session["EstabelecimentoID"].ToString()),
                enderecoID = endereco.enderecoID
            };
            _context.estabelecimentosEnderecos.Add(estabelecimentoEndereco);
            _context.SaveChanges();
        }

        [HttpPut]
        private void atualizar(endereco endereco)
        {
            var enderecoAtual = _context.enderecos.Where(e => e.enderecoID == endereco.enderecoID).SingleOrDefault();
            enderecoAtual.logradouro = endereco.logradouro;
            enderecoAtual.numero = endereco.numero;
            enderecoAtual.complemento = endereco.complemento;
            enderecoAtual.bairro = endereco.bairro;
            enderecoAtual.cep = endereco.cep;
            enderecoAtual.latitude = endereco.latitude;
            enderecoAtual.longitude = endereco.longitude;
            enderecoAtual.cidadeID = endereco.cidadeID;
            enderecoAtual.estadoID = endereco.estadoID;

            _context.SaveChanges();
        }
    }
}