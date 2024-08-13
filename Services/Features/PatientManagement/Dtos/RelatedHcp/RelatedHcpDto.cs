using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos.RelatedHcp;

public class RelatedHcpDto
{
    public int Id { get; set; }
    [Required] public string Type { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string Telephone { get; set; }
    [Required] public string Fax { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Website { get; set; }
    public Guid PatientId { get; set; }
}