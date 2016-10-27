using System;
using System.Globalization;

namespace BlankXamarinApp.Core.Helpers
{
    public class DateHelper
    {
        public static string ApiDateToString(string apiDate)
        {
            var dt = DateTime.ParseExact(apiDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            return dt.ToString("dd/MM/yyyy");
        }

        public static DateTime ApiDateToDate(string apiDate)
        {
            return DateTime.ParseExact(apiDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static string DateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }

        // ReSharper disable once InconsistentNaming
        public static string yyyyMMddToString(string date)
        {
            DateTime theTime= DateTime.ParseExact(date,
                                        "yyyy-MM-dd",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None);
            return theTime.ToString("dd/MM/yyyy");
        }

        public static int DaysBetweenDatesApiFormat(string start, string end)
        {
            var startDate =  DateTime.ParseExact(start, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(end, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            return DaysBetweenDates(startDate, endDate);
        }

        public static int DaysBetweenDates(DateTime start, DateTime end)
        {
			return end.Date.Subtract (start.Date).Days;
        }

        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }
        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
    }
}
