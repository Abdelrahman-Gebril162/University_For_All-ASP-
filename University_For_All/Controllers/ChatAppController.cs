using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University_For_All.Controllers
{
    public class ChatAppController : Controller
    {
        // GET: ChatApp
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}