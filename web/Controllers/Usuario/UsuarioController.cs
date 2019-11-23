using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using web.Models.Usuario;
using web.Repository.DBConn;
using web.ViewModel.Usuario;

namespace web.Controllers.Usuario
{
    public class usuarioController : Controller
    {
        private DBConn _context;

        public usuarioController()
        {
            _context = new DBConn();
        }

        public ActionResult Default()
        {
            var login = Session["UserName"];

            if (Session.IsNewSession || login == null)
            {
                return Redirect("~/");
            }
            else
            {
                return RedirectToAction("listar", "produto");
            }
        }

        /// <summary>
        /// usuario/getByLogin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult login(usuario obj)
        {
            try
            {
                usuario usuario = new usuario();
                
                if(obj != null)
                    usuario = _context.usuarios.Where(u => u.login == obj.login && u.senha == obj.senha).SingleOrDefault();

                if (usuario != null && usuario.ativo)
                {
                    Session["UserId"] = usuario.usuarioID;
                    Session["UserName"] = usuario.login;
                    Session["EstabelecimentoId"] = usuario.estabelecimentoID;

                    return RedirectToAction("listar", "pedido");
                }
                else
                {
                    return View("login");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult logout()
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("login");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult listar()
        {
            try
            {
                // Obtém os usuários do estabelecimento
                var usuarios = getUsuariosEstabelecimento();

                var viewModel = new usuarioListarViewModel()
                {
                    usuarios = usuarios,
                    ativo = true
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult novo()
        {
            try
            {
                // Obtém o ID do estabelecimento
                var estabelecimentoId = int.Parse(Session["EstabelecimentoId"].ToString());


                var usuario = new usuario()
                {
                    estabelecimento = _context.estabelecimentos.Where(e => e.estabelecimentoID == estabelecimentoId).SingleOrDefault()
                };

                return View("form", usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult editar(int id)
        {
            try
            {
                var usuario = _context.usuarios.Where(u => u.usuarioID == id).SingleOrDefault();

                // Obtém o ID do estabelecimento
                var estabelecimentoId = int.Parse(Session["EstabelecimentoId"].ToString());

                usuario.estabelecimento = _context.estabelecimentos.Where(e => e.estabelecimentoID == estabelecimentoId).SingleOrDefault();

                return View("form", usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult salvar(usuario usuario)
        {
            try
            {
                usuario.estabelecimentoID = usuario.estabelecimento.estabelecimentoID;

                if (usuario.usuarioID > 0)
                {
                    atualizar(usuario);
                }
                else
                {
                    inserir(usuario);
                }

                return RedirectToAction("listar");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public void inserir(usuario usuario)
        {
            // Insere na tabela usuario
            _context.usuarios.Add(usuario);
            _context.SaveChanges();
        }

        [HttpPut]
        public void atualizar(usuario usuario)
        {
            var usuarioAtual = _context.usuarios.Where(u => u.usuarioID == usuario.usuarioID).SingleOrDefault();
            usuarioAtual.login = usuario.login;
            usuarioAtual.senha = usuario.senha;
            usuarioAtual.ativo = usuario.ativo;
            _context.SaveChanges();
        }

        public ActionResult pesquisar(usuarioListarViewModel usuarioPesquisa)
        {
            try
            {
                // Obtém os usuários do estabelecimento
                var usuarios = getUsuariosEstabelecimento();

                if (usuarioPesquisa.login != null)
                {
                    usuarios = usuarios.Where(u => u.login.Contains(usuarioPesquisa.login)).ToList();
                }

                usuarios = usuarios.Where(u => u.ativo.Equals(usuarioPesquisa.ativo)).ToList();

                var viewModel = new usuarioListarViewModel()
                {
                    usuarios = usuarios,
                    ativo = usuarioPesquisa.ativo
                };

                return View("listar", viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Obtém o id do estabelecimento da session
        private int getEstabelecimentoID()
        {
            return int.Parse(Session["EstabelecimentoId"].ToString());
        }

        // Obtém os usuarios do estabelecimento
        private IEnumerable<usuario> getUsuariosEstabelecimento()
        {
            var estabelecimentoId = getEstabelecimentoID();
            return _context.usuarios.Where(u => u.estabelecimentoID == estabelecimentoId).OrderBy(u => u.login).ToList();
        }
    }
}