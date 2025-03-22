namespace NachtWiesel.Tools.Dates;

public static class DateOnlyExtensions
{
    private static readonly TimeOnly _emptyTime = new TimeOnly(0, 0, 0);
    public static DateTime? ToDateTime(this DateOnly? date)
        => date == null ? null : date.Value.ToDateTime(_emptyTime);
    public static DateTime ToDateTime(this DateOnly date)
        => date.ToDateTime(_emptyTime);
    public static DateOnly GetNextWeekday(this DateOnly start, DayOfWeek day)
    {
        int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
        return start.AddDays(daysToAdd);
    }
    public static int Age(this DateOnly birthDate, DateOnly laterDate)
    {
        int age;
        age = laterDate.Year - birthDate.Year;

        if (age > 0)
        {
            age -= Convert.ToInt32(laterDate < birthDate.AddYears(age));
        }
        else
        {
            age = 0;
        }

        return age;
    }
    public static int Age(this DateOnly birthDate)
        => birthDate.Age(DateOnly.FromDateTime(DateTime.Today));
    public static DateOnly GetDateOnlyQuarterStart(this int quarter, int year)
        => new DateOnly(year, quarter * 3 - 2, 1);
    public static DateOnly GetDateOnlyQuarterEnd(this int quarter, int year)
    {
        int endMonth = quarter * 3;
        int endDay = DateTime.DaysInMonth(year, endMonth);
        return new DateOnly(year, endMonth, endDay);
    }
    public static DateOnly GetDateOnlyYearEnd(this int year)
        => new DateOnly(year, 12, DateTime.DaysInMonth(year, 12));
    public static int GetCurrentQuarter(this DateOnly date)
        => date.Month / 4 + 1;
}
