using MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class MenuController : Controller
    {
        public PartialViewResult Menu(int selectedLink = 0)
        {
            var viewModel = new Menu();
            List<LinkInfo> linksInfo = new List<LinkInfo>();
            linksInfo.Add(new LinkInfo { LinkText = "Home", ControllerName = "Home", ActionName = "Index" });
            linksInfo.Add(new LinkInfo { LinkText = "Friends", ControllerName = "Friend", ActionName = "Index" });
            linksInfo.Add(new LinkInfo { LinkText = "Messages", ControllerName = "Dialog", ActionName = "Index" });
            linksInfo.Add(new LinkInfo { LinkText = "Options", ControllerName = "Options", ActionName = "Index" });
            viewModel.SelectedLink = selectedLink;
            viewModel.LinksInfo = linksInfo;
            return PartialView(viewModel);
        }

    }
}
