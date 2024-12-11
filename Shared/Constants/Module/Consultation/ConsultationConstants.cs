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


    public static class DocumentConstant
    {
        public const string Letters = "Letters";
        public const string Sketches = "Sketches";
        public const string Documents = "Documents";

        public static List<DocumentType> DocumentTypesList { get; set; } =
        [
            new(1, "Letter"),
            new(2, "Document"),
        ];

       
    }
}

public class ReactionType(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

public class DocumentType(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}
