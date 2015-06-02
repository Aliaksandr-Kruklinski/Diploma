using BLL.Interface.Abstract;
using MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class FriendController : Controller
    {
        private IUserQueryService userQueryService;

        public FriendController(IUserQueryService userQueryService)
        {
            this.userQueryService = userQueryService;
        }

        public ActionResult Index(string query)
        {
            var users = userQueryService.GetAllUsers();
            var validUsers = users.Select(u => this.userQueryService.GetUser(u.Id)).ToList().Where(u => u.IsApproved);
            var model = validUsers.Select(u => new Guest { Profile = u.Profile.ToWeb(), UserId = u.Id }).ToList();
            return View(model);
        }



    }
}
