using System.ComponentModel.DataAnnotations;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Settings;

public class Clinic
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Branch { get; set; }

    public virtual ICollection<User> Users { get; set; }
}