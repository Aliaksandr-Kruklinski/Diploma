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
    public class HomeController : Controller
    {
        private IMessageRepository messageRepository;
        private IImageRepository imageRepository;

        public HomeController(IMessageRepository messageRepository, IImageRepository imageRepository)
        {
            this.messageRepository = messageRepository;
            this.imageRepository = imageRepository;
        }

        public ViewResult Index(int page = 1)
        {
            HomeModel model = new HomeModel();
            ViewBag.SelectedPage = page;
            UserInfo userInfo = new UserInfo();
            userInfo = (UserInfo)HttpContext.Profile["UserInfo"];
            model.Info = userInfo;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        {
            try
            {
                String messageText = model.MessageText;
                Message message = new Message
                {
                    MessageID = 0,
                    UserID = Membership.GetUser(this.User.Identity.Name).ProviderUserKey.ToString(),
                    DialogID = Membership.GetUser(this.User.Identity.Name).ProviderUserKey.ToString(),
                    Text = messageText,
                    Time = DateTime.Now
                };
                messageRepository.SaveMessage(message);
                model.MessageText = null;
                return RedirectToAction("Index");
            }
            catch
            {
                model.MessageText = null;
                return RedirectToAction("Index");
            }
        }

        public FileContentResult GetAvatar()
        {
            Image userAvatar = imageRepository.GetAvatar(Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString());
            if (userAvatar != null)
            {
                return File(userAvatar.ImageData, userAvatar.ImageMimeType);
            }
            return null;
        }
    }
}
