using BLL.Interface.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IProfileService profileService;

        public HomeController(IProfileService profileService)
        {
            if (profileService == null)
            {
                throw new System.ArgumentNullException("profileService", "Profile service is null.");
            }
            this.profileService = profileService;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
