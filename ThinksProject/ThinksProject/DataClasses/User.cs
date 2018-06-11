using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinksProject.DataClasses;

namespace ThinksProject
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string TelegramPassword { get; set; }
		public long TelegramChatId { get; set; }
	}
}
