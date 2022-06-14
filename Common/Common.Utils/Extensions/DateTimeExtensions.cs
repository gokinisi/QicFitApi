
using System;

namespace Common.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime WeekBefore(this DateTime dt, int shift = 1)
        {
            return dt.Date.AddDays(-7 * shift);
        }

        public static DateTime YearBefore(this DateTime dt, int shift = 1)
        {
            return dt.Date.AddYears(-1 * shift);
        }

        public static DateTime MonthBefore(this DateTime dt, int shift = 1)
        {
            return dt.Date.AddMonths(-1 * shift);
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek = DayOfWeek.Sunday)
        {
            var diff = (7 + (endOfWeek - dt.DayOfWeek)) % 7;
            return dt.AddDays(diff).Date;
        }

        public static DateTime StartOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
        }

        public static DateTime StartOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }

        public static DateTime EndOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 12, DateTime.DaysInMonth(dt.Year, dt.Month));
        }

        public static DateTime ResetTimeToStartOfDay(this DateTime dateTime)
        {
            return new DateTime(
               dateTime.Year,
               dateTime.Month,
               dateTime.Day,
               0, 0, 0, 0);
        }

        public static DateTime ResetTimeToEndOfDay(this DateTime dateTime)
        {
            return new DateTime(
               dateTime.Year,
               dateTime.Month,
               dateTime.Day,
               23, 59, 59, 999);
        }

        public static DateTime CreateDateTime(this DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, 
                                time.Hour, time.Minute, time.Second);
         }
    }
}
