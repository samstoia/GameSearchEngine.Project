using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class RatingController: Controller
	{
		[HttpGet("/rating")]
		public ActionResult Index()
		{
		return View();
		}
	}
}