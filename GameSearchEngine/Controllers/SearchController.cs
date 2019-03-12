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
		}

		[HttpGet("/search/results")]
		public ActionResult Show()
		{
			List<Game> allGames = Game.GetAll();
			return View(allGames);
		}

	}


}