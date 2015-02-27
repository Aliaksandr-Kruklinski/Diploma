using SocialNetwork.Domain.Abstract;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class ImageController : Controller
    {
        private IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public FileContentResult GetAvatar(string userID)
        {
            Image userAvatar = imageRepository.GetAvatar(userID);
            if (userAvatar != null)
            {
                return File(userAvatar.ImageData, userAvatar.ImageMimeType);
            }
            return null;
        }
    }
}
