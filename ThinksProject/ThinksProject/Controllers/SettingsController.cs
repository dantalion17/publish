using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinksProject.DataClasses;

namespace ThinksProject.Controllers
{
	[Authorize]
	public class SettingsController : Controller
	{
		private readonly DbWorking _dbWorking;

		public SettingsController(DbWorking dbWorking)
		{
			_dbWorking = dbWorking;
		}
		public IActionResult Index()
		{
			var model = _dbWorking.GetCurrentUserSetting(User.Identity.Name) ?? new UserSetting();
			return View(model);
		}

		[HttpPost]
		public IActionResult EditSendCount(string Count)
		{
			var sendMessageCount = int.Parse(Count);
			_dbWorking.SaveOrChangeDayStatistic(User.Identity.Name, sendMessageCount);
			return RedirectToAction("Index", "Home");
		}


	}
}