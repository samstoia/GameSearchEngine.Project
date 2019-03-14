using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GameSearchEngine.Models;

namespace GameSearchEngine.Controllers
{
	public class AddGameController: Controller
	{
		[HttpGet("/addgame")]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost("/addgame/thank-you")]
		public ActionResult Thanks(string title, string description, string genre, string platforms, string yearReleased, int rating, string imageLarge = "", string thumbnailImage = "")
		{
			Game newGame = new Game(title, description, genre, platforms, yearReleased, rating, imageLarge, thumbnailImage);
			newGame.Save();
			return View();
		}
	}
}
