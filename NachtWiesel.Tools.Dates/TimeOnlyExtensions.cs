namespace NachtWiesel.Tools.Dates;

public static class TimeOnlyExtensions
{
    public static DateTime? ToDateTime(this TimeOnly? time)
        => time == null ? null : time.Value.ToDateTime();
    public static DateTime ToDateTime(this TimeOnly time)
        => new DateTime(1, 1, 1, time.Hour, time.Minute, time.Second);
}
