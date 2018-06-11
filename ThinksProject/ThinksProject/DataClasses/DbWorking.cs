using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThinksProject.Data;
using ThinksProject.DL;

namespace ThinksProject.DataClasses
{
	public class DbWorking
	{
		private readonly DataDbContext _context;

		public DbWorking(DataDbContext context)
		{
			_context = context;
		}

		public void SaveOrChangeDayStatistic(string UserEmail, int CountSendOfDay)
		{
			var UserSetting = _context.UserSettings.Include(x => x.User).FirstOrDefault(x => x.User.Email == UserEmail);

			if (UserSetting == null)
			{
				UserSetting = new UserSetting()
				{
					CountPostInDay = CountSendOfDay,
					User = _context.Users.First(x => x.Email == UserEmail)
				};
				_context.UserSettings.Add(UserSetting);
				_context.SaveChanges();
				return;
			}

			UserSetting.CountPostInDay = CountSendOfDay;
			_context.SaveChanges();
		}

		public List<Post> GetAllPosts(string UserEmail)
		{
			var allPostsList = _context.PostInformations
				.Include(x => x.User).Where(x => x.User.Email == UserEmail)
				.Include(x => x.Posts).Select(x => x.Posts)
				.OrderByDescending(x => x.DateCreate).ToList();
			return allPostsList;
		}

		private List<Post> GetPostsInInterval(string UserEmail, TimeSpan Interval)
		{
			var allPostsList = _context.PostInformations
				.Include(x => x.User).Where(x => x.User.Email == UserEmail)
				.Include(x => x.Posts).Select(x => x.Posts)
				.Where(x => x.DateCreate > DateTime.Now)
				.OrderByDescending(x => x.DateCreate).ToList();
			return allPostsList;
		}

		public List<Post> GetPostsInMonth(string UserEmail)
		{
			var monthAgo = CalendarOperations.GetTimeSpanEqualsDayIsCurrentMonth();
			return GetPostsInInterval(UserEmail,monthAgo);
		}

		public List<Post> GetPostsInWeek(string UserEmail)
		{
			var weekAgo = CalendarOperations.GetTimeSpanEqualsSevenDays();
			return GetPostsInInterval(UserEmail, weekAgo);
		}

		public List<Post> GetPostsInDay(string UserEmail)
		{
			var dayAgo = CalendarOperations.GetTimeSpanEqualsOneDay();
			return GetPostsInInterval(UserEmail, dayAgo);
		}

		public void UserAndUserSettingsCreate(string Name,string Surname,string UserEmail)
		{
			var tgPass = SecretGenerate.RandomString(7);
			var User = new User()
			{
				Name = Name,
				Surname = Surname,
				Email = UserEmail,
				TelegramPassword = tgPass
			};
			_context.Users.Add(User);
			_context.SaveChanges();
			UserSetting userSetting = new UserSetting()
			{
				CountPostInDay = 6,
				User = User
			};
			_context.SaveChanges();
			
		}

		public UserSetting GetCurrentUserSetting(string email)
		{
			var userSetting = _context.UserSettings.Include(x => x.User).FirstOrDefault(x => x.User.Email.Equals(email));
			return userSetting;
		}

		public string GetTgPass(string userEmail)
		{
			var tgPass = _context.Users.First(x => x.Email == userEmail).TelegramPassword;
			return tgPass;
		}
	}
}
