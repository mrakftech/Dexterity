using Services.State;

namespace Services.Features.Consultation.Dto.Immunisations;

public class AdministerShotDto
{
    public DateTime DueDate { get; set; }
    public DateTime GivenDate { get; set; }
    public string Side { get; set; }
    public Guid HcpId { get; set; } = ApplicationState.CurrentUser.UserId;
    public string HcpName { get; set; }
    public string Dose { get; set; }
    public string Method { get; set; }
    public string Manufacture { get; set; }
    public string TradeName { get; set; }
    public string BatchNumber { get; set; }
    public DateTime Expiry { get; set; }
}