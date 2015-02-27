using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Domain.Abstract;
using SocialNetwork.Domain.Entities;
using SocialNetwork.WebUI.Controllers;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.UnitTests.WebUI
{
    [TestClass]
    public class _MenuController
    {

        [TestMethod]
        public void MenuController_Menu_SelectedDialog()
        {
            MenuController controller = new MenuController();

            MenuModel resultHome = ((MenuModel)controller.Menu(0).Model);
            MenuModel resultFriends =((MenuModel)controller.Menu(1).Model);
            MenuModel resultMessages =((MenuModel)controller.Menu(2).Model);
            MenuModel resultOptions = ((MenuModel)controller.Menu(3).Model);

            Assert.AreEqual(0, resultHome.SelectedLink);
            Assert.AreEqual(1, resultFriends.SelectedLink);
            Assert.AreEqual(2, resultMessages.SelectedLink);
            Assert.AreEqual(3, resultOptions.SelectedLink);
        }
    }
}
