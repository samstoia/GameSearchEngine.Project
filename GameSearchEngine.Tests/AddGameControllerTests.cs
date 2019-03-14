using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameSearchEngine.Controllers;
using GameSearchEngine.Models;

namespace GameSearchEngine.Tests
{
    [TestClass]
    public class AddGameControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            AddGameController controller = new AddGameController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Thanks_ReturnsCorrectView_True()
        {
            AddGameController controller = new AddGameController();
            ActionResult thanksView = controller.Thanks("Game", "A good game", "Action", "Xbox", "1990", 5, "", "");
            Assert.IsInstanceOfType(thanksView, typeof(ViewResult));
        }
    }
}