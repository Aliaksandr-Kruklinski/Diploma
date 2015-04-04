using SocialNetwork.Domain.Abstract;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        public int PageSize = 10;
        private IMessageRepository repository;

        public MessageController(IMessageRepository messageRepository)
        {
            repository = messageRepository;
        }

        public PartialViewResult List(string controllerName,string dialogID, int page = 1)
        {
            GetPageSize();
            MessagePagingModel viewModel = new MessagePagingModel
            {
                Messages = repository.Messages
                    .Where(m =>dialogID==null||m.DialogID==dialogID)
                    .OrderBy(m => m.Time)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                Paginglnfo = new Paginglnfo
                {
                    ControllerName = controllerName,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = dialogID == null ? repository.Messages.Count() : repository.Messages.Where(e => e.DialogID == dialogID).Count()
                },
                CurrentDialog = dialogID
            };
            return PartialView(viewModel);
        }

        private void GetPageSize()
        {
            try
            {
                UserInfo userInfo = new UserInfo();
                userInfo = (UserInfo)HttpContext.Profile["UserInfo"];
                if (userInfo.PageSize != 0)
                {
                    PageSize = userInfo.PageSize;
                }
            }
            catch
            {
            }
        }
    }
}
