using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YMWeb.Web.Controllers
{
    public class HomesController : Controller
    {
        // GET: HomesController
        public ActionResult Index()
        {
            return View();
        }

    
    }
}
