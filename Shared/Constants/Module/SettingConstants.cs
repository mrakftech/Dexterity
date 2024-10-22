namespace Shared.Constants.Module;

public static class SettingConstants
{
    public static List<IntervalType> IntervalTypes { get; set; } =
    [
        new IntervalType(1, "From Birth", 56, 0),
        new IntervalType(2, "Since Last Shot", 56, 112)
    ];

    public static List<Dose> Doses { get; set; } =
    [
        new Dose(1, "0.5ML"),
        new Dose(2, "1ML"),
        new Dose(3, "2ML"),
        new Dose(4, "3ML"),
    ];

    public static List<DoseMethod> Methods { get; set; } =
    [
        new DoseMethod(1, "IM"),
        new DoseMethod(1, "IV"),
        new DoseMethod(2, "INJ/IM/SC"),
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