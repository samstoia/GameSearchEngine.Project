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
			return View();
			// List<Game> allGames = Game.GetAll();
			// return View(allGames);
		}

		[HttpPost("/search/results")]
		public ActionResult Show(string userInput, string genre, string platform, string yearStart, string yearEnd)
		{
			List<Game> selectedGames = Game.GetSelected(userInput, genre, platform, yearStart, yearEnd);
			return View(selectedGames);
		}

	}


}