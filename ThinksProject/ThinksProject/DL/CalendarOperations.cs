using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksProject.DL
{
    public static class CalendarOperations
    {
	    public static TimeSpan GetTimeSpanEqualsDayIsCurrentMonth()
	    {
		    var year = DateTime.Now.Year;
		    var month = DateTime.Now.Month;
		    var countDayInCurrentMonth = DateTime.DaysInMonth(year, month);
		    TimeSpan monthAgo = new TimeSpan(countDayInCurrentMonth);
		    return monthAgo;
	    }

		public static TimeSpan GetTimeSpanEqualsSevenDays()
		{
			var weekAgo = new TimeSpan(7);
			return weekAgo;
		}

	    public static TimeSpan GetTimeSpanEqualsOneDay()
	    {
		    var weekAgo = new TimeSpan(1);
		    return weekAgo;
	    }
	}
}
