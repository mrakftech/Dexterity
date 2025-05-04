namespace Shared.Constants.Module;

public static class SettingConstants
{
    public static List<InvestigationFieldType> FieldTypes { get; set; } =
    [
        new(1, "Text"),
        new(2, "Number"),
        new(3, "Decimal"),
        new(4, "Date"),
        new(5, "List Selection"),
    ];

    #region Immunisations

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

    #endregion
    
    #region Drugs
    public static List<PackType> PackTypes { get; set; } =
    [
        new(1, "Box"),
        new(2, "Bottle"),
        new(3, "Blister"),
        new(4, "Tube"),
    ];
    public static List<PackSize> PackSizes { get; set; } =
    [
        new(1, "10"),
        new(2, "20"),
        new(2, "30"),
        new(3, "50"),
        new(4, "100"),
    ];
    public static List<PackSizeMark> PackSizeMarks { get; set; } =
    [
        new(1, "Tablets"),
        new(2, "Capsules"),
        new(2, "mL"),
        new(3, "g"),
    ];
    public static List<DrugStrength> DrugStrengths { get; set; } =
    [
        new(1, "50mg"),
        new(2, "100mg"),
        new(3, "250mg"),
        new(4, "500mg"),
    ];
    public static List<PrescriptionType> PrescriptionTypes { get; set; } =
    [
        new(1, "Acute"),
    ];
    public static List<ScriptType> ScriptTypes { get; set; } =
    [
        new(1, "Private"),
    ];
    public class PackType(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }

    public class PackSize(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        
    }

    public class PackSizeMark(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
      
    }

    public class DrugStrength(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
      
    }
    
    public class PrescriptionType(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
      
    }
    public class ScriptType(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
      
    }
    #endregion
}

public enum TransactionActionType
{
    Charge,
    Payment,
    StrikeOff
}

public class InvestigationFieldType(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

#region Immunisations

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

#endregion


