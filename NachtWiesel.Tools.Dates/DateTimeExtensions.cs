namespace NachtWiesel.Tools.Dates;

public static class DateTimeExtensions
{
    public static DateOnly? ToDateOnly(this DateTime? dateTime)
        => dateTime == null ? null : dateTime.Value.ToDateOnly();
    public static DateOnly ToDateOnly(this DateTime dateTime)
        => DateOnly.FromDateTime(dateTime);
    public static TimeOnly? ToTimeOnly(this DateTime? dateTime)
        => dateTime == null ? null : dateTime.Value.ToTimeOnly();
    public static TimeOnly ToTimeOnly(this DateTime dateTime)
        => TimeOnly.FromDateTime(dateTime);
    public static DateTime GetNextWeekday(this DateTime start, DayOfWeek day)
    {
        int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
        return start.AddDays(daysToAdd);
    }
    public static int Age(this DateTime birthDate, DateTime laterDate)
    {
        int age;
        age = laterDate.Year - birthDate.Year;

        if (age > 0)
        {
            age -= Convert.ToInt32(laterDate.Date < birthDate.Date.AddYears(age));
        }
        else
        {
            age = 0;
        }

        return age;
    }
    public static int Age(this DateTime birthDate)
        => birthDate.Age(DateTime.Today);
    public static DateTime AddBusinessDays(this DateTime date, int days)
    {
        if (days < 0)
        {
            throw new ArgumentException("days cannot be negative", "days");
        }
        if (days == 0) return date;
        if (date.DayOfWeek == DayOfWeek.Saturday)
        {
            date = date.AddDays(2);
            days -= 1;
        }
        else if (date.DayOfWeek == DayOfWeek.Sunday)
        {
            date = date.AddDays(1);
            days -= 1;
        }
        date = date.AddDays(days / 5 * 7);
        int extraDays = days % 5;
        if ((int)date.DayOfWeek + extraDays > 5)
        {
            extraDays += 2;
        }
        return date.AddDays(extraDays);
    }
    public static DateTime GetQuarterStart(this int quarter, int year)
        => new DateTime(year, quarter * 3 - 2, 1);
    public static DateTime GetQuarterEnd(this int quarter, int year)
    {
        int endMonth = quarter * 3;
        int endDay = DateTime.DaysInMonth(year, endMonth);
        return new DateTime(year, endMonth, endDay);
    }
    public static DateTime GetYearEnd(this int year)
        => new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
    public static int GetCurrentQuarter(this DateTime date)
        => date.Month / 4 + 1;
    public static object? ToLegalOleDateOrString(this DateTime time, string? nonLegal = "Неверный формат даты")
    {
        if (time.Year < 100 || time.Year > 9999)
        {
            return nonLegal;
        }
        return time;
    }

    public static object? ToLegalOleDateOrString(this DateOnly date, string? nonLegal = "Неверный формат даты")
    {
        if (date.Year < 100 || date.Year > 9999)
        {
            return nonLegal;
        }
        return date.ToDateTime();
    }
}