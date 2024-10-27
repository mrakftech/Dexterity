namespace Shared.Constants.Module;

public static class SettingConstants
{
    public static List<IntervalType> IntervalTypes { get; set; } =
    [
        new(1, "From Birth", 56, 0),
        new(2, "Since Last Shot", 56, 112)
    ];

    public static List<Dose> Doses { get; set; } =
    [
        new(1, "0.5ML"),
        new(2, "1ML"),
        new(3, "2ML"),
        new(4, "3ML"),
    ];

    public static List<DoseMethod> Methods { get; set; } =
    [
        new(1, "Oral"),
        new(1, "IM"),
        new(1, "IV"),
        new(2, "INJ/IM/SC"),
    ];

    public static List<Side> Sides { get; set; } =
    [
        new(1, "Bilateral Nares"),
        new(2, "LAT"),
        new(3, "Left Deltoid"),
        new(4, "Left Side"),
        new(5, "Left Thigh"),
        new(6, "Left Upper Arm"),
        new(7, "Oral"),
        new(8, "RAT"),
        new(9, "Right Deltoid"),
        new(10, "Right Side"),
        new(11, "Right Thigh"),
    ];
}

public enum TransactionActionType
{
    Charge,
    Payment,
    StrikeOff
}

public class IntervalType(int id, string name, int min, int max)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int Min { get; set; } = min;
    public int Max { get; set; } = max;
}

public class Dose(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

public class DoseMethod(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

public class Side(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}