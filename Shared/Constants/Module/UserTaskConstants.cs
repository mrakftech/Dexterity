namespace Shared.Constants.Module;

public static class UserTaskConstants
{
    public const string All = "All";
    public const string DayView = "Day";
    public const string WeekView = "Week";
    public const string MonthView = "Month";


    public static class TaskStatusConstant
    {
        public const string Active = "Active";
        public const string Inactive = "Inactive";
        public const string InProgress = "In Progress";
        public const string Postponed = "Postponed";
        public const string Complete = "Complete";
        public const string Cancelled = "Cancelled";

    }
    public static List<TaskStatus> TaskStatusList { get; set; } =
    [
        new(1, "Active"),
        new(2, "Inactive"),
        new(3, "In Progress"),
        new(4, "Complete"),
        new(5, "Cancelled"),
    ];

    public class TaskStatus(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}

