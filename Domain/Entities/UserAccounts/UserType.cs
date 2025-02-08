using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.UserAccounts;

public class UserType : IBaseId
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    public bool IsDefualt { get; set; }
}