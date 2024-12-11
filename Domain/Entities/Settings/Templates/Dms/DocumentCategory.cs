using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities.Settings.Templates.Dms;

public class DocumentCategory
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; }

    public int? ParentCategoryId { get; set; } // Nullable for root categories

    [ForeignKey("ParentCategoryId")]
    public DocumentCategory ParentCategory { get; set; } // Navigation property for the parent

    public ICollection<DocumentCategory> SubCategories { get; set; } = new List<DocumentCategory>();
}