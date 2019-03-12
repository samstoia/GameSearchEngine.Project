using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class GenreController: Controller
	{
		[HttpGet("/genre")]
		public ActionResult Index()
		{
		return View();
		}

		[HttpGet("/genre/action")]
		public ActionResult Action()
		{
		return View();
		}

		[HttpGet("/genre/adventure")]
		public ActionResult Adventure()
		{
		return View();
		}

		[HttpGet("/genre/compilation")]
		public ActionResult Compilation()
		{
		return View();
		}

		[HttpGet("/genre/puzzle")]
		public ActionResult Puzzle()
		{
		return View();
		}

		[HttpGet("/genre/racingdriving")]
		public ActionResult RacingDriving()
		{
		return View();
		}
		[HttpGet("/genre/roleplaying")]
		public ActionResult RolePlaying()
		{
		return View();
		}
		[HttpGet("/genre/simulation")]
		public ActionResult Simulation()
		{
		return View();
		}

		[HttpGet("/genre/sports")]
		public ActionResult Sports()
		{
		return View();
		}

		[HttpGet("/genre/strategy")]
		public ActionResult Strategy()
		{
		return View();
		}
	}

	
}