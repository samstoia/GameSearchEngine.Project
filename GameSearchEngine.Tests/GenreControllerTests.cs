using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameSearchEngine.Controllers;
using GameSearchEngine.Models;

namespace GameSearchEngine.Tests
{
    [TestClass]
    public class GenreControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            GenreController controller = new GenreController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            GenreController controller = new GenreController();
            ActionResult thanksView = controller.Show("Action");
            Assert.IsInstanceOfType(thanksView, typeof(ViewResult));
        }

        [TestMethod]
        public void ShowGame_ReturnsCorrectView_True()
        {
            GenreController controller = new GenreController();
            ActionResult thanksView = controller.ShowGame(9);
            Assert.IsInstanceOfType(thanksView, typeof(ViewResult));
        }
    }
}