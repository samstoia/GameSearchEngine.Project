using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameSearchEngine.Controllers;
using GameSearchEngine.Models;

namespace GameSearchEngine.Tests
{
    [TestClass]
    public class SearchControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            SearchController controller = new SearchController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            SearchController controller = new SearchController();
            ActionResult thanksView = controller.Show("Action", "Xbox", "1990", "Banana Game");
            Assert.IsInstanceOfType(thanksView, typeof(ViewResult));
        }
    }
}