using SocialNetwork.Domain.Abstract;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class MenuController : Controller
    {
        public PartialViewResult Menu(int? selectedLink = null)
        {
            MenuModel viewModel = new MenuModel();
            List<LinkInfo> linksInfo = new List<LinkInfo>();
            linksInfo.Add(new LinkInfo { LinkText = "Home", ControllerName = "Home", ActionName = "Index" });
            linksInfo.Add(new LinkInfo { LinkText = "Friends", ControllerName = "Friend", ActionName = "Index" });
            linksInfo.Add(new LinkInfo { LinkText = "Messages", ControllerName = "Dialog", ActionName = "Index" });
            linksInfo.Add(new LinkInfo { LinkText = "Options", ControllerName = "Option", ActionName = "Index" });
            viewModel.SelectedLink = selectedLink == null ? 0 : (int)selectedLink;
            viewModel.LinksInfo = linksInfo;
            return PartialView(viewModel);
        }
    }
}
