using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameSearchEngine.Models;
using System.Collections.Generic;
using System;

namespace GameSearchEngine.Tests
{
  [TestClass]
  public class GameTest : IDisposable
  {

    public void Dispose()
    {
      Game.ClearAll();
    }

    public GameTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=game_test;";
    }


    [TestMethod]
    public void GameConstructor_CreatesInstanceOfGame_Game()
    {
      Game newGame = new Game("test", "test", "test", "test", "test", 1, "test", "test");
      Assert.AreEqual(typeof(Game), newGame.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "super mario world";
      Game newGame = new Game(title, "test", "test", "test", "test", 1, "test", "test");
      string result = newGame.GetTitle();
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void GetId_ReturnsId_String()
    {
      string title = "super mario world";
      Game newGame = new Game(title, "test", "test", "test", "test", 1, "test", "test");
      int result = newGame.GetId();
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Game testGame = new Game("test", "test", "test", "test", "test", 1, "test", "test");
      testGame.Save();
      Game savedGame = Game.GetAll()[0];
      int result = savedGame.GetId();
      int testId = testGame.GetId();
      Assert.AreEqual(testId, result);
    }




  }
}
