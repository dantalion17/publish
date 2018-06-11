using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksProject.DataClasses
{
    public class ActiveList
    {
		public int Id { get; set; }
		public long TgChatId { get; set; }
		public bool IsEndWrite { get; set; }
		public int DateTimeLastChangeIsEndWriteHours { get; set; }
    }
}
