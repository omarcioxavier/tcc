using System;
using System.Linq;
using System.Web.Mvc;
using web.Models.Cliente;
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
        public ActionResult List()
        {
            try
            {
                var result = _context.clientes.OrderBy(c => c.nome).ToList();
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult getByParameters(cliente obj)
        {
            try
            {
                var result = _context.clientes.OrderBy(c => c.nome).ToList();
                
                if (!string.IsNullOrEmpty(obj.nome))
                {
                    result = result.Where(r => r.nome == obj.nome).ToList();
                }

                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}