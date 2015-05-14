using BLL.Interface.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUI.Models;

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
            var model = HttpContext.Profile.ToWeb();
            if (model.Birthday.Value.Year.CompareTo(DateTime.Today.Year - 100) <= 0) model.Birthday = null;
            return View(model);
        }

    }
}
