using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        //
        // GET: /Friend/

        public ActionResult Index()
        {
            return View();
        }

    }
}
