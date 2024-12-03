using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Templates;

public class LetterType : IBaseId
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
}