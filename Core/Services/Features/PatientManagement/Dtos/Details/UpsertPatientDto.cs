using System.ComponentModel.DataAnnotations;
using Shared.Attributes;
using Shared.Constants.Module;
using Shared.Helper;

namespace Services.Features.PatientManagement.Dtos.Details
{
    public class UpsertPatientDto
    {
        [Required(ErrorMessage = "*")] public string FamilyName { get; set; }
        [Required(ErrorMessage = "*")] public string FirstName { get; set; }
        [Required(ErrorMessage = "*")] public string LastName { get; set; }

        public string IhiNumber { get; set; } = CryptographyHelper.GetUniqueKey();
        public string Ppsn { get; set; }
        public string BirthSurname { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public Gender Gender { get; set; }
        public PatientType PatientType { get; set; }
        public PatientStatus PatientStatus { get; set; }
        public bool DispensingStatus { get; set; }

        public string HomePhone { get; set; }
        [Required(ErrorMessage = "*")] public string MobilePhone { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress]
        public string Email { get; set; }

        [NotEmpty(ErrorMessage = "Please select HCP")]
        public Guid HcpId { get; set; }

        [Range(1,Int32.MaxValue,ErrorMessage = "*")]public int ClinicId { get; set; }

        #region Address

        [Required(ErrorMessage = "*")] public string AddressLine1 { get; set; }
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

        // [GmsNumber(ErrorMessage = "Invalid GMS number e.g: M567890A or 3130132D")]
        public string GmsPatientNumber { get; set; } = "A123456B";

        public DateTime GmsReviewDate { get; set; } = DateTime.Now;
        public string GmsDoctorNumber { get; set; }
        public string GmsDistanceCode { get; set; }

        #endregion

    }
}