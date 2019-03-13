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

		// [HttpGet("/genre/adventure")]
		// public ActionResult Adventure()
		// {
		// return View();
		// }

		// [HttpGet("/genre/compilation")]
		// public ActionResult Compilation()
		// {
		// return View();
		// }

		// [HttpGet("/genre/puzzle")]
		// public ActionResult Puzzle()
		// {
		// return View();
		// }

		// [HttpGet("/genre/racingdriving")]
		// public ActionResult RacingDriving()
		// {
		// return View();
		// }
		// [HttpGet("/genre/roleplaying")]
		// public ActionResult RolePlaying()
		// {
		// return View();
		// }
		// [HttpGet("/genre/simulation")]
		// public ActionResult Simulation()
		// {
		// return View();
		// }

		// [HttpGet("/genre/sports")]
		// public ActionResult Sports()
		// {
		// return View();
		// }

		// [HttpGet("/genre/strategy")]
		// public ActionResult Strategy()
		// {
		// return View();
		// }
	}


}
