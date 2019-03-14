using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameSearchEngine.Controllers;
using GameSearchEngine.Models;

namespace GameSearchEngine.Tests
{
    [TestClass]
    public class RatingControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            RatingController controller = new RatingController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            RatingController controller = new RatingController();
            ActionResult thanksView = controller.Show(1);
            Assert.IsInstanceOfType(thanksView, typeof(ViewResult));
        }
    }
}