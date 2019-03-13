using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using GameSearchEngine.Models;

namespace GameSearchEngine.Controllers
{
	public class GenreController: Controller
	{
		[HttpGet("/genre")]
		public ActionResult Index()
		{
		return View();
		}

		[HttpPost("/genre/show")]
		public ActionResult Show(string genreName)
		{
			List<Game> allGames = Game.GetGenre(genreName);
			return View(allGames);
		}

		[HttpGet("/genre/game/{id}")]
		public ActionResult ShowGame(int id)
		{
			Dictionary<string, object> model = new Dictionary<string, object>();
			Game selectedGame = Game.Find(id);
			model.Add("selectedGame", selectedGame);
			return View(model);
		}

	}


}
