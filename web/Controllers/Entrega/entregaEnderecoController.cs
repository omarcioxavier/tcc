using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Entrega
{
    public class entregaEnderecoController : Controller
    {
        private DBConn _context;

        public entregaEnderecoController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// entregaEndereco/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.entregasEnderecos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// entregaEndereco/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.entregasEnderecos.Where(e => e.entregaEnderecoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}