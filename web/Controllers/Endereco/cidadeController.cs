using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers.Endereco
{
    public class cidadeController : Controller
    {
        private DBConn _context;

        public cidadeController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// cidade/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.cidades, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// cidade/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.cidades.Where(e => e.cidadeID == id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// cidade/getByEstadoId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getByEstadoId(int id)
        {
            return Json(_context.cidades.Where(e => e.estadoID == id), JsonRequestBehavior.AllowGet);
        }
    }
}