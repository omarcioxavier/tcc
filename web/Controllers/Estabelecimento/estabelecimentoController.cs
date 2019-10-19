using System;
using System.Linq;
using System.Web.Mvc;
using web.Models.Estabelecimento;
using web.Models.Usuario;
using web.Repository.DBConn;
using web.ViewModel.Estabelecimento;

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
        public estabelecimento getById(int id)
        {
            return _context.estabelecimentos.Where(e => e.estabelecimentoID == id).SingleOrDefault();
        }

        public ActionResult novo()
        {
            try
            {
                var viewModel = new estabelecimentoNovoViewModel()
                {
                    estabelecimentoCategorias = _context.estabelecimentosCategorias.ToList()
                };
                return View(viewModel);
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
                var estabelecimentoID = int.Parse(Session["EstabelecimentoId"].ToString());
                var estabelecimento = _context.estabelecimentos.Where(e => e.estabelecimentoID == estabelecimentoID).SingleOrDefault();
                return View(estabelecimento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult salvar(estabelecimento estabelecimento, usuario usuario = null)
        {
            try
            {
                if (estabelecimento.estabelecimentoID > 0)
                {
                    // Editar
                    atualizar(estabelecimento);
                    return RedirectToAction("listar");
                }
                else
                {
                    // Novo
                    inserir(estabelecimento, usuario);
                    return RedirectToAction("Default", "usuario");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        private void inserir(estabelecimento estabelecimento, usuario usuario)
        {
            // Insere o estabelecimento
            _context.estabelecimentos.Add(estabelecimento);
            _context.SaveChanges();

            // Insere o usuário
            usuario.ativo = true;
            usuario.estabelecimentoID = estabelecimento.estabelecimentoID;
            _context.usuarios.Add(usuario);
            _context.SaveChanges();
        }

        [HttpPut]
        private void atualizar(estabelecimento estabelecimento)
        {
            // Trata o estabelecimento
            var estabelecimentoAtual = _context.estabelecimentos.Where(e => e.estabelecimentoID == estabelecimento.estabelecimentoID).SingleOrDefault();
            estabelecimentoAtual.razaoSocial = estabelecimento.razaoSocial;
            estabelecimentoAtual.nomeFantasia = estabelecimento.nomeFantasia;
            estabelecimentoAtual.cnpj = estabelecimento.cnpj;
            estabelecimentoAtual.inscricaoEstadual = estabelecimento.inscricaoEstadual;
            estabelecimentoAtual.ativo = estabelecimento.ativo;
            estabelecimentoAtual.estabelecimentoCategoriaID = estabelecimento.estabelecimentoCategoriaID;
            _context.SaveChanges();
        }
    }
}