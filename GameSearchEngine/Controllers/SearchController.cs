using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class SearchController: Controller
	{
		[HttpGet("/search")]
		public ActionResult Index()
		{
		return View();
		}
	}
}