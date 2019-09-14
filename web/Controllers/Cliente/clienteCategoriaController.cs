using System;
using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Cliente
{
    public class clienteCategoriaController : Controller
    {
        private DBConn _context;

        public clienteCategoriaController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// clienteCategoria/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            try
            {
                return Json(_context.clientesCategorias, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// clienteCategoria/getById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            try
            {
                return Json(_context.clientesCategorias.Where(c => c.clienteCategoriaID == id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}