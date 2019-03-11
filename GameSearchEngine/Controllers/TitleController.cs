using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class TitleController: Controller
	{
		[HttpGet("/title")]
		public ActionResult Index()
		{
		return View();
		}
	}
}