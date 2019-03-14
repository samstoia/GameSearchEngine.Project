using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameSearchEngine.Controllers;
using GameSearchEngine.Models;

namespace GameSearchEngine.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            GenreController controller = new GenreController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}