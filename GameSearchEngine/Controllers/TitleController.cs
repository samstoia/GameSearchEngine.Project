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
	}
}