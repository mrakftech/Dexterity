namespace Shared.Constants.Module.Consultation;

public static class PrescriptionsConstants
{
    public static class Status
    {
        public const string ToPrint = "To Print";
        public const string Current = "Current";
        public const string Printed = "Printed";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";
        public const string Audit = "Audit";
    }

    public enum PrescriptionType
    {
        Acute,
        Repeat
    }

    public enum InitiatedEnum
    {
        Primary,
        Secondary,
        Unspecified
    }

    public static List<PerscriptionStatus> PerscriptionStatusList { get; set; } =
    [
        new(1, "To Print"),
        new(2, "Current"),
        new(3, "Printed"),
        new(4, "Completed"),
        new(5, "Cancelled"),
        new(6, "Audit"),
    ];

    public class PerscriptionStatus(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}