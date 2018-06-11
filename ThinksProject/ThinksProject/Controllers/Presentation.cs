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
	public class PresentationController:Controller
    {
		private readonly DbWorking _dbWorking;

		public PresentationController(DbWorking dbWorking)
	    {
			_dbWorking = dbWorking;
	    }
	    public IActionResult AllStatistics()
	    {
		    var allPosts = _dbWorking.GetAllPosts(User.Identity.Name);
		    return View(allPosts);
	    }
		public IActionResult LastMonthStatistics()
		{
			var allPosts = _dbWorking.GetPostsInMonth(User.Identity.Name);
			return View("AllStatistics",allPosts);
		}

	    public IActionResult LastWeekStatistics()
	    {
		    var allPosts = _dbWorking.GetPostsInWeek(User.Identity.Name);
		    return View("AllStatistics",allPosts);
	    }

	    public IActionResult LastDayStatistics()
	    {
		    var allPosts = _dbWorking.GetPostsInDay(User.Identity.Name);
		    return View("AllStatistics",allPosts);
	    }
	   
	}
}
