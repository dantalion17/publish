using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksProject.DataClasses
{
	public class UserSetting
	{
		public int Id { get; set; }
		public User User { get; set; }
		public int CountPostInDay { get; set; }
	}
}
