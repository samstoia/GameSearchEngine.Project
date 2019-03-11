using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class HomeController: Controller
	{
		[HttpGet("/")]
		public ActionResult Index()
		{
		return View();
		}
	}
}