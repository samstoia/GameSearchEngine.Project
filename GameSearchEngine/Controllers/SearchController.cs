using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GameSearchEngine.Models;

namespace GameSearchEngine.Controllers
{
	public class SearchController: Controller
	{
		[HttpGet("/search")]
		public ActionResult Index()
		{
			List<Game> allGames = Game.GetAll();
			return View(allGames);
		}

		[HttpPost("/search/results")]
		public ActionResult Show(string genre, string platform, string yearStart, string userInput)
		{
			List<Game> selectedGames = Game.GetSelected(genre, platform, yearStart, userInput);
			Console.WriteLine("{0}, {1}, {2}, {3}", genre, platform, yearStart, userInput);
			return View(selectedGames);
		}

	}


}