using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUI.Models;
using MvcUI.Providers.Entities;
using BLL.Interface.Abstract;
using System.Web.Security;
using MvcUI.Providers;

namespace MvcUI.Controllers
{
    public class OptionsController : Controller
    {
        IImageService imageService;

        public OptionsController(IImageService imageService)
        {
            if (imageService == null)
            {
                throw new System.ArgumentNullException("imageService", "Image service is null.");
            }
            this.imageService = imageService;
        }

        public ActionResult Index()
        {
            var model = HttpContext.Profile.ToWeb();
            if (string.IsNullOrEmpty(model.FirstName)) model.FirstName = "First name";
            if (string.IsNullOrEmpty(model.SecondName)) model.SecondName = "Second Name";
            if (model.Birthday.Value.Year.CompareTo(DateTime.Today.Year - 100) < 0) model.Birthday = DateTime.Today.AddYears(-100);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Models.Membership.Profile model, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        Image newAvater = new Image { MimeType = image.ContentType, Data = new byte[image.ContentLength] };
                        image.InputStream.Read(newAvater.Data, 0, image.ContentLength);
                        string userId = Membership.GetUser(this.User.Identity.Name).ProviderUserKey.ToString();
                        this.imageService.LoadImage(userId, newAvater.ToBll());
                        HttpContext.Profile["Avatar"] = newAvater;
                    }

                    HttpContext.Profile["FirstName"] = model.FirstName;
                    HttpContext.Profile["SecondName"] = model.SecondName;
                    HttpContext.Profile["Birthday"] = model.Birthday.Value;
                }
                return RedirectToAction("Index", new { selectedLink = 3 });
            }
            catch
            {
                return RedirectToAction("Index", new { selectedLink = 3 });
            }
        }

        public FileContentResult GetAvatar()
        {
            Image userAvatar = HttpContext.Profile["Avatar"] == null ? null : (Image)HttpContext.Profile["Avatar"];
            if (userAvatar != null)
            {
                return File(userAvatar.Data, userAvatar.MimeType);
            }
            return null;
        }
    }
}
