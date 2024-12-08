using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Templates.Forms;

public class CustomFormTemplate : IBaseId
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    [Required(ErrorMessage = "required")] public string Description { get; set; }

    public CustomForm CustomForm { get; set; }
    public Guid CustomFormId { get; set; }
}