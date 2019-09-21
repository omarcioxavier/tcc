using System;
using System.Linq;
using System.Web.Mvc;
using web.Models.Usuario;
using web.Repository.DBConn;

namespace web.Controllers.Usuario
{
    public class usuarioController : Controller
    {
        private DBConn _context;

        public usuarioController()
        {
            _context = new DBConn();
        }

        // GET: Usuario
        public ActionResult Default()
        {
            return View();
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
                var usuario = _context.usuarios.Where(u => u.login == obj.login && u.senha == obj.senha).SingleOrDefault();

                if (usuario != null)
                {
                    updateSessionState(usuario, true);

                    return RedirectToAction("list", "cliente");
                }
                else
                {
                    return View("Default");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza o estado da sessão do usuário
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <param name="status"></param>
        [HttpPut]
        public void updateSessionState(usuario usuario, bool status)
        {
            try
            {
                if (status)
                {
                    // USUÁRIO LOGADO
                    usuario.estadoSessao = true;
                }
                else
                {
                    // USUÁRIO NÃO LOGADO
                    usuario.estadoSessao = false;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult NaoEncontrado(usuario usuario)
        {
            return View(usuario);
        }
    }
}