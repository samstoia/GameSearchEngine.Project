using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class ReleaseDateController: Controller
	{
		[HttpGet("/releasedate")]
		public ActionResult Index()
		{
		return View();
		}
	}
}