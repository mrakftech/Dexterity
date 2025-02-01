namespace Shared.Constants.Module.Common;

public static class FlagRecordConstant
{
    public static class Module
    {
        public const string ConsultationDetail = "Consultation Details";
        public const string Notes = "Notes";

    }
    public static List<FlagReason> FlagReasons { get; set; } =
    [
        new(1, "Wrong Patient"),
        // new(2, "Duplicate Entry"),
        // new(3, "Incorrect Data"),
    ];
    
    
    public class FlagReason(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}