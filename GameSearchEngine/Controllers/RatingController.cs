using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GameSearchEngine.Models;

namespace GameSearchEngine.Controllers
{
	public class RatingController: Controller
	{
		[HttpGet("/rating")]
		public ActionResult Index()
		{
			List<Game> allGames = Game.GetRatingOrdered();
			return View(allGames);
			
		}

		[HttpGet("/rating/{id}")]
		public ActionResult Show(int id)
		{
			Dictionary<string, object> model = new Dictionary<string, object>();
			Game selectedGame = Game.Find(id);
			model.Add("selectedGame", selectedGame);
			return View(model);
		}
	}
}