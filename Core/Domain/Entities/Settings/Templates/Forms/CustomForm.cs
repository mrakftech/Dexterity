using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Shared.Constants.Module;

namespace Domain.Entities.Settings.Templates.Forms;

public class CustomForm : IBaseId
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "required")] public string Name { get; set; }
    [Required(ErrorMessage = "required")]  public string Description { get; set; }
    public CustomFormType Type { get; set; }
    public string BasedOn { get; set; }
    public bool IsActive { get; set; }
}