using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SocialNetwork.WebUI.HtmlHelpers;

namespace SocialNetwork.UnitTests.WebUI
{
    [TestClass]
    public class _PagingHelpers
    {
        [TestMethod]
        public void PagingHelpers_PageLinks_Urls()
        {
            HtmlHelper myHelper = null;
            Paginglnfo paginglnfo = new Paginglnfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = myHelper.PageLinks(paginglnfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");
        }

    }
}
