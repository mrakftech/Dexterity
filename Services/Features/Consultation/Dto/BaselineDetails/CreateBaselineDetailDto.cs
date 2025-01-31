using System.ComponentModel.DataAnnotations;
using Services.State;

namespace Services.Features.Consultation.Dto.BaselineDetails;

public class CreateBaselineDetailDto
{
    #region Physical Measurement

    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Date { get; set; } = DateTime.Now;

    [Range(1, double.MaxValue, ErrorMessage = "Required")]
    public float Weight { get; set; }

    public double Stone { get; set; }


    [Range(1, double.MaxValue, ErrorMessage = "Required")]
    public float Height { get; set; }

    public double HeightInFt { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Required")]
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

    [Range(1, double.MaxValue, ErrorMessage = "Required")]
    public int Systolic { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Required")]
    public int Diastolic { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Required")]
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

    public Guid PatientId { get; set; } = ApplicationState.SelectedPatient.PatientId;
    public Guid HcpId { get; set; } = ApplicationState.Auth.CurrentUser.UserId;
}