using BLL.Interface.Abstract;
using MvcUI.Models;
using MvcUI.Providers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUI.Providers;

namespace MvcUI.Controllers
{
    public class WallController : Controller
    {
        public int PageSize = 10;
        private IWallService wallService;
        private IUserQueryService userQueryService;

        public WallController(IWallService wallService, IUserQueryService userQueryService)
        {
            this.wallService = wallService;
            this.userQueryService = userQueryService;
        }

        public PartialViewResult List(string controllerName, string userId, int page = 1)
        {
            var user = userQueryService.GetUser(userId);
            if (user != null)
            {
                var viewModel = new WallMessagePagingModel
                {

                    WallMessages = this.wallService.GetAllMessages(user.Wall)
                        .OrderBy(m => m.Time)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        .Select( m => m.ToWeb()),
                    Paginglnfo = new Paginglnfo
                    {
                        ControllerName = controllerName,
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = this.wallService.GetAllMessages(user.Wall).Count()
                    },
                    userId = userId
                };
                return PartialView(viewModel);
            }
            return PartialView();
        }


        public FileContentResult GetAvatar(string userId)
        {
            int imageId = (int)HttpContext.Profile["Avatar"];
            Image userAvatar = null;
            if (imageId != -1)
            {
                userAvatar = this.userQueryService.GetUser(userId).Images.Where(i => i.Id == imageId).First().ToWeb();
            }
            if (userAvatar != null)
            {
                return File(userAvatar.Data, userAvatar.MimeType);
            }
            return null;
        }
    }
}
