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
    public class _MessageController
    {
        [TestMethod]
        public void MessageController_List_Paginate()
        {
            Mock<IMessageRepository> mock = new Mock<IMessageRepository>();
            mock.Setup(m => m.Messages).Returns(
                new Message[] 
                {
                    new Message {MessageID = 1, UserID = "1", DialogID = "1", Text ="1", Time = new DateTime(2014,7,11,18,23,01)},
                    new Message {MessageID = 2, UserID = "1", DialogID = "1", Text ="2", Time = new DateTime(2014,7,11,18,23,02)},
                    new Message {MessageID = 3, UserID = "1", DialogID = "1", Text ="3", Time = new DateTime(2014,7,11,18,23,03)},
                    new Message {MessageID = 4, UserID = "1", DialogID = "1", Text ="4", Time = new DateTime(2014,7,11,18,23,04)},
                    new Message {MessageID = 5, UserID = "1", DialogID = "1", Text ="5", Time = new DateTime(2014,7,11,18,23,05)},
                }.AsQueryable());
            MessageController controller = new MessageController(mock.Object);
            controller.PageSize = 3;

            MessagePagingModel resultFirstPage = (MessagePagingModel)controller.List(null, "1",1).Model;
            MessagePagingModel resultSecondPage = (MessagePagingModel)controller.List(null, "1",2).Model;

            Message[] messages = resultFirstPage.Messages.ToArray();
            Assert.IsTrue(messages.Length == 3);
            Assert.AreEqual(messages[0].Text, "1");
            Assert.AreEqual(messages[1].Text, "2");
            Assert.AreEqual(messages[2].Text, "3");
            messages = resultSecondPage.Messages.ToArray();
            Assert.IsTrue(messages.Length == 2);
            Assert.AreEqual(messages[0].Text, "4");
            Assert.AreEqual(messages[1].Text, "5");
        }

        [TestMethod]
        public void MessageController_List_ViewModel()
        {
            Mock<IMessageRepository> mock = new Mock<IMessageRepository>();
            mock.Setup(m => m.Messages).Returns(
                new Message[] 
                {
                    new Message {MessageID = 1, UserID = "1", DialogID = "1", Text ="1", Time = new DateTime(2014,7,11,18,23,01)},
                    new Message {MessageID = 2, UserID = "1", DialogID = "1", Text ="2", Time = new DateTime(2014,7,11,18,23,02)},
                    new Message {MessageID = 3, UserID = "1", DialogID = "1", Text ="3", Time = new DateTime(2014,7,11,18,23,03)},
                    new Message {MessageID = 4, UserID = "1", DialogID = "1", Text ="4", Time = new DateTime(2014,7,11,18,23,04)},
                    new Message {MessageID = 5, UserID = "1", DialogID = "1", Text ="5", Time = new DateTime(2014,7,11,18,23,05)},
                }.AsQueryable());
            MessageController controller = new MessageController(mock.Object);
            controller.PageSize = 3;

            MessagePagingModel resultFirstPage = (MessagePagingModel)controller.List(null, "1",1).Model;
            MessagePagingModel resultSecondPage = (MessagePagingModel)controller.List(null, "1",2).Model;

            Paginglnfo pagelnfo = resultFirstPage.Paginglnfo;
            Assert.AreEqual(pagelnfo.CurrentPage, 1);
            Assert.AreEqual(pagelnfo.ItemsPerPage, 3);
            Assert.AreEqual(pagelnfo.TotalItems, 5);
            Assert.AreEqual(pagelnfo.TotalPages, 2);
            pagelnfo = resultSecondPage.Paginglnfo;
            Assert.AreEqual(pagelnfo.CurrentPage, 2);
            Assert.AreEqual(pagelnfo.ItemsPerPage, 3);
            Assert.AreEqual(pagelnfo.TotalItems, 5);
            Assert.AreEqual(pagelnfo.TotalPages, 2);
        }

        [TestMethod]
        public void MessageController_List_Dialogs()
        {
            Mock<IMessageRepository> mock = new Mock<IMessageRepository>();
            mock.Setup(m => m.Messages).Returns(
                new Message[] 
                {
                    new Message {MessageID = 1, UserID = "1", DialogID = "1", Text ="1", Time = new DateTime(2014,7,11,18,23,01)},
                    new Message {MessageID = 2, UserID = "1", DialogID = "2", Text ="2", Time = new DateTime(2014,7,11,18,23,02)},
                    new Message {MessageID = 3, UserID = "1", DialogID = "1", Text ="3", Time = new DateTime(2014,7,11,18,23,03)},
                    new Message {MessageID = 4, UserID = "1", DialogID = "2", Text ="4", Time = new DateTime(2014,7,11,18,23,04)},
                    new Message {MessageID = 5, UserID = "1", DialogID = "3", Text ="5", Time = new DateTime(2014,7,11,18,23,05)},
                }.AsQueryable());
            MessageController controller = new MessageController(mock.Object);
            controller.PageSize = 3;

            Message[] result = ((MessagePagingModel)controller.List(null,"2", 1).Model).Messages.ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].MessageID == 2 && result[0].DialogID == "2");
            Assert.IsTrue(result[1].MessageID == 4 && result[1].DialogID == "2");
        }
    }
}