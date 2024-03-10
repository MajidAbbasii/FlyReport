using System.Globalization;

namespace FlyApp;

public static class DateExtension
{
    public static string ToPersianDateTime(this DateTime datetime)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        return
            $"{persianCalendar.GetYear(datetime)}/{persianCalendar.GetMonth(datetime)}/{persianCalendar.GetDayOfMonth(datetime)}-{persianCalendar.GetHour(datetime)}:{persianCalendar.GetMinute(datetime)}";
    }
}