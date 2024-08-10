using System.ComponentModel.DataAnnotations;
using Services.Configurations.Attributes;
using Services.Features.PatientManagement.Dtos.Get;
using Syncfusion.Blazor.TreeGrid.Internal;
using static Shared.Constants.Module.PatientConstants;
using static Shared.Constants.Module.PatientConstants.PatientType;
using static Shared.Constants.Module.PatientConstants.Status;

namespace Services.Features.PatientManagement.Dtos.Upsert
{
    public class UpsertPatientDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Required")] public string FamilyName { get; set; }
        [Required(ErrorMessage = "Required")] public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")] public string LastName { get; set; }

        public string IhiNumber { get; set; }
        public string UniqueNumber { get; set; } = "0000";
        public string Ppsn { get; set; }
        public string BirthSurname { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public Gender Gender { get; set; }
        public PatientTypes PatientType { get; set; }
        public PatientStatus PatientStatus { get; set; }
        public bool DispensingStatus { get; set; }

        public string HomePhone { get; set; }
        [Required(ErrorMessage = "Required")] public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }

        [NotEmpty(ErrorMessage = "Please select HCP")]
        public Guid HcpId { get; set; }

        #region Address

        [Required(ErrorMessage = "Required")] public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; } = "";
        public string City { get; set; } = "";
        public string County { get; set; } = "";
        public string EriCode { get; set; } = "";
        public string Country { get; set; } = "";

        #endregion

        #region Medical Card Detail

        public bool IsGmsActive { get; set; }

        public string GmsStatus { get; set; } = "Inactive";
        public string GmsDoctor { get; set; }

        [GmsNumber(ErrorMessage = "Invalid GMS number e.g: M567890A or 3130132D")]
        public string GmsPatientNumber { get; set; } = "A123456B";

        public DateTime GmsReviewDate { get; set; } = DateTime.Now;
        public string GmsDoctorNumber { get; set; }
        public string GmsDistanceCode { get; set; }

        #endregion
    }
}