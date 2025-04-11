using System.ComponentModel.DataAnnotations;

namespace Services.Features.Consultation.Dto.Letter;

public class EmailDto
{
    [EmailAddress] public string To { get; set; }
    public string Cc { get; set; }
    public string Details { get; set; }
    public string Subject { get; set; }
    public string AttachFile { get; set; }
    
    public List<string> Attachments { get; set; } = new();
    public List<string> CcList { get; set; } = new();
    
}