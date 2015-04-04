using SocialNetwork.Domain.Abstract;
using SocialNetwork.Domain.Entities;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.WebUI.Controllers
{
    [Authorize]
    public class OptionController : Controller
    {
        private IImageRepository imageRepository;

        public OptionController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public ViewResult Index()
        {
            UserInfo userInfo = new UserInfo();
            userInfo = (UserInfo)HttpContext.Profile["UserInfo"];
            return View(userInfo);
        }

        [HttpPost]
        public ActionResult Index(UserInfo info,HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    if (image != null)
                    {
                        Image newAvater = new Image { ImageMimeType = image.ContentType, ImageData = new byte[image.ContentLength] };
                        image.InputStream.Read(newAvater.ImageData, 0, image.ContentLength);
                        newAvater.ImageID = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();
                        imageRepository.SaveImage(newAvater);
                    }
                }
                HttpContext.Profile["UserInfo"] = info;
                return RedirectToAction("Index", new { selectedLink = 3 });
            }
            catch
            {
                return RedirectToAction("Index", new { selectedLink = 3});
            }

        }

    }
}
