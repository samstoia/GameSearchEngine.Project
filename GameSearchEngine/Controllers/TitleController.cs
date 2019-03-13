using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GameSearchEngine.Models;

namespace GameSearchEngine.Controllers
{
	public class TitleController: Controller
	{
		[HttpGet("/title")]
		public ActionResult Index()
		{
			List<Game> allGames = Game.GetAll();
			return View(allGames);
		}

		[HttpGet("/title/game/{id}")]
		public ActionResult Show(int id)
		{
			Dictionary<string, object> model = new Dictionary<string, object>();
			Game selectedGame = Game.Find(id);
			model.Add("selectedGame", selectedGame);
			return View(model);
		}

	}
}
