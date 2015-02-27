using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SocialNetwork.Domain.Abstract;
using SocialNetwork.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain.Concrete;
using SocialNetwork.WebUI.Infrastructure.Abstract;
using SocialNetwork.WebUI.Infrastructure.Concrete;

namespace SocialNetwork.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }

        /// <summary>
        /// Registration Domain
        /// </summary>
        private void AddBindings()
        {
            ninjectKernel.Bind<IMessageRepository>().To<EFMessageRepository>();
            ninjectKernel.Bind<IImageRepository>().To<EFImageRepository>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            ninjectKernel.Bind<IVerifyProvider>().To<EmailVerifyProvider>();
        }
    }
}