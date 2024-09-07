namespace Domain.Entities.Consultation;

public class BaselineDetail
{
    public int Id { get; set; }

    #region Physical Measurement

    public DateTime Date { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }
    public float Bmi { get; set; }
    public string BloodGroup { get; set; }
    public float AbdominalCircumference { get; set; }

    #endregion

    #region Social History

    public bool SmokerStatus { get; set; }
    public int SmokePerDay { get; set; }
    public DateTime SmokingStartDate { get; set; }
    public int ExSmokerYears { get; set; }
    public bool DrinkingStatus { get; set; }
    public int WeeklyAlcohol { get; set; }
    public DateTime DrinkingStartDate { get; set; }
    public bool FamilyCvdHistory { get; set; }
    public bool Lvh { get; set; }

    #endregion

    #region Bp, Pulse, and Other

    public int Systolic { get; set; }
    public int Diastolic { get; set; }
    public float Cholesterol { get; set; }
    public float Ldl { get; set; }
    public float Hdl { get; set; }
    public int Pulse { get; set; }
    public string PulseRhythm { get; set; }
    public float Temperature { get; set; }
    public int PeakFlow { get; set; }
    public int RespiratoryRate { get; set; }
    public string CurrentOccupation { get; set; }
    public string SubtanceMisuse { get; set; }

    #endregion

    public ConsultationDetail ConsultationDetail { get; set; }
    public int ConsultationDetailId { get; set; }
}