using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameSearchEngine.Controllers
{
	public class AddGameController: Controller
	{
        [HttpGet("/addgame")]
		public ActionResult Index()
		{
		return View();
		}
    }
}
