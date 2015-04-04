using SocialNetwork.WebUI.Infrastructure.Abstract;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Controllers
{
    public class VerifyController : Controller
    {
        IVerifyProvider verifyProvider;

        public VerifyController(IVerifyProvider verifyProvider)
        {
            this.verifyProvider = verifyProvider;
        }

        [OutputCache(Duration = 60)]
        public ActionResult Index(ActivateModel model)
        {
            if (model.Email != null)
            {
                if (verifyProvider.IsApproved(model.Email))
                {
                    MailAddress mailAddress = new MailAddress(model.Email);
                    if (mailAddress != null)
                    {
                        ViewBag.userHost = mailAddress.Host;
                        ViewBag.userEmail = model.Email;
                        return View();
                    }
                }
            }
            return RedirectToAction("LogIn","Account");
        }

        public ActionResult Verify(ActivateModel model)
        {
            if (model.Email != null && model.SecretCode != null)
            {
                if (verifyProvider.Verify(model.Email, model.SecretCode))
                {
                    return RedirectToAction("LogIn", "Account");
                }
            }
            return RedirectToAction("SignUp", "Account");
        }

    }
}
