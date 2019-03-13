using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GameSearchEngine.Models;

namespace GameSearchEngine.Controllers
{
	public class PlatformController: Controller
	{
		[HttpGet("/platform")]
		public ActionResult Index()
		{
		return View();
		}

		[HttpPost("/platform/show")]
		public ActionResult Show(string platformName)
		{
			List<Game> allGames = Game.GetPlatform(platformName);
			return View(allGames);
		}

		[HttpGet("/platform/game/{id}")]
		public ActionResult ShowGame(int id)
		{
			Dictionary<string, object> model = new Dictionary<string, object>();
			Game selectedGame = Game.Find(id);
			model.Add("selectedGame", selectedGame);
			return View(model);
		}

	}
}
