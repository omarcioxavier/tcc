using System.Linq;
using System.Web.Mvc;
using web.Repository.DBConn;

namespace web.Controllers
{
    public class logController : Controller
    {
        private DBConn _context;

        public logController()
        {
            _context = new DBConn();
        }

        /// <summary>
        /// log/getAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAll()
        {
            return Json(_context.logs, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// log/getById
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getById(int id)
        {
            return Json(_context.logs.Where(l => l.logID == id), JsonRequestBehavior.AllowGet);
        }
    }
}