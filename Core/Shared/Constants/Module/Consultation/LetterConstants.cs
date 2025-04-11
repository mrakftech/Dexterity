namespace Shared.Constants.Module.Consultation;

public static class LetterConstants
{
    public static class Status
    {
        public const string Cancelled = "Cancelled";
        public const string Completed = "Completed";
        public const string Active = "Active";

    }
    
    public static List<ReferenceTo> ReferenceToList { get; set; } =
    [
        new(1, "The Patient"),
    ];
}

public class ReferenceTo(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}