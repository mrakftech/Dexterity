using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos.Options;

public class HospitalDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "*")] public string Name { get; set; }
    [Required(ErrorMessage = "*")] public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string AlsoKnownAs { get; set; }
    public string HealthBoard { get; set; }
    public string HealthCode { get; set; }

    //Contact Details
    [Required(ErrorMessage = "*")]  public string Contact { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostCode { get; set; }
}