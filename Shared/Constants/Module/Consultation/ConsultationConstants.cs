namespace Shared.Constants.Module.Consultation;

public static class ConsultationConstants
{
    public static List<ReactionType> ReactionTypes { get; set; } =
    [
        new(1, "Temperature"),
        new(2, "Localized Pain"),
        new(3, "Drowsiness"),
        new(4, "Vomiting"),
        new(5, "Pain"),
        new(6, "High Fever"),
        new(7, "Vomiting"),
        new(8, "Diarrhea"),
        new(9, "Red Rush"),
        new(10, "Convulsions"),
        new(11, "Anaphylaxix"),
        new(12, "Itching"),
        new(13, "Breathing Problems"),
        new(14, "Dizziness"),
        new(15, "Headache"),
        new(16, "Loss of Appetite"),
        new(17, "Muscle Aches"),
        new(18, "Head Cold"),
        new(19, "Swelling of Glands"),
        new(20, "Crying"),
    ];

    public static class InvestigationStatus
    {
        public const string Awaiting = "Awaiting";
        public const string InReview = "In Review";
        public const string FollowUp = "Follow up";
        public const string Complete = "Complete";
    }
}

public class ReactionType(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}