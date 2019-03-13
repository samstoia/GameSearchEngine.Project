using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GameSearchEngine.Models;

namespace GameSearchEngine.Controllers
{
	public class ReleaseDateController: Controller
	{
		[HttpGet("/releasedate")]
		public ActionResult Index()
		{
			List<Game> allGames = Game.GetYearOrdered();
			return View(allGames);
		}

		[HttpGet("/releasedate/{id}")]
		public ActionResult Show(int id)
		{
			Dictionary<string, object> model = new Dictionary<string, object>();
			Game selectedGame = Game.Find(id);
			model.Add("selectedGame", selectedGame);
			return View(model);
		}
	}
}
