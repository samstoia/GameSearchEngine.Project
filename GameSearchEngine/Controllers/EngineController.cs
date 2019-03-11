using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class EngineController: Controller
	{
		[HttpGet("/engine")]
		public ActionResult Index()
		{
		return View();
		}
	}
}