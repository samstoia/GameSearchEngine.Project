using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class PlatformController: Controller
	{
		[HttpGet("/platform")]
		public ActionResult Index()
		{
		return View();
		}
	}
}