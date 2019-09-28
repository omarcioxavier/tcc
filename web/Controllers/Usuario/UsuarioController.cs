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
            if (Session.IsNewSession)
            {
                return View();
            }
            else
            {
                return RedirectToAction("list", "cliente");
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
                var usuario = _context.usuarios.Where(u => u.login == obj.login && u.senha == obj.senha).SingleOrDefault();

                if (usuario != null)
                {
                    Session["Name"] = usuario.login;

                    return RedirectToAction("list", "cliente");
                }
                else
                {
                    TempData["message"] = "erro";
                    return View("Default");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Default");
        }

        public ActionResult NaoEncontrado(usuario usuario)
        {
            return View(usuario);
        }
    }
}