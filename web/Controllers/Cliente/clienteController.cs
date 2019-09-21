using System;
using System.Linq;
using System.Web.Mvc;
using web.Models.Usuario;
using web.Repository.DBConn;

namespace web.Controllers.Cliente
{
    public class clienteController : Controller
    {
        private DBConn _context;

        public clienteController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// cliente/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            try
            {
                return Json(_context.clientes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// cliente/getById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            try
            {
                return Json(_context.clientes.Where(c => c.clienteID == id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// cliente/index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult list()
        {
            try
            {
                var clientes = _context.clientes.OrderBy(c => c.nome).ToList();
                return View(clientes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult details(int id)
        {
            try
            {
                var cliente = _context.clientes.Where(c => c.clienteID == id).SingleOrDefault();
                return View(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}