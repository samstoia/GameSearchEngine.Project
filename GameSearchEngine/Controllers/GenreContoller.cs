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
	}
}