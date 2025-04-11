namespace Shared.Constants.Module.Consultation;

public class SmokerStatus(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;


    public static List<SmokerStatus> SmokerStatusList { get; set; } =
    [
        new SmokerStatus(1, "Current Smoker"),
        new SmokerStatus(2, "Former Smoker"),
        new SmokerStatus(3, "Never Smoked"),
        new SmokerStatus(4, "Unknown"),
    ];
}