using Domain.Entities.Settings.Consultation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

public class DiagnosisCodeConfiguration : IEntityTypeConfiguration<DiagnosisCode>
{
    public void Configure(EntityTypeBuilder<DiagnosisCode> builder)
    {
        builder.HasData(new List<DiagnosisCode>()
        {
            new() {Id = 1, Code = "C00", Description = "Malignant neoplasm of lip"},
            new() {Id = 2, Code = "C00.0", Description = "External upper lip"},
            new() {Id = 3, Code = "C00.1", Description = "External lower lip"},
            new() {Id = 4, Code = "C00.2", Description = "External lip, unspecified"},
            new() {Id = 5, Code = "C00.3", Description = "Upper lip, inner aspect"},
            new() {Id = 6, Code = "C00.4", Description = "Lower lip, inner aspect"},
            new() {Id = 7, Code = "C00.5", Description = "Lip, unspecified, inner aspect"},
            new() {Id = 8, Code = "C00.6", Description = "Commissure of lip"},
            new() {Id = 9, Code = "C00.8", Description = "Overlapping lesion of lip"},
            new() {Id = 10, Code = "C00.9", Description = "Lip, unspecified"},
            new() {Id = 11, Code = "C01", Description = "Malignant neoplasm of base of tongue"},
            new() {Id = 12, Code = "C02", Description = "Malignant neoplasm of other and unspecified parts of tongue"},
            new() {Id = 13, Code = "C02.0", Description = "Dorsal surface of tongue"},
            new() {Id = 14, Code = "C02.1", Description = "Border of tongue"},
            new() {Id = 15, Code = "C02.2", Description = "Ventral surface of tongue"},
            new() {Id = 16, Code = "C02.3", Description = "Anterior two-thirds of tongue, part unspecified"},
            new() {Id = 17, Code = "C02.4", Description = "Lingual tonsil"},
            new() {Id = 18, Code = "C02.8", Description = "Overlapping lesion of tongue"},
            new() {Id = 19, Code = "C02.9", Description = "Tongue, unspecified"},
            new() {Id = 20, Code = "C03", Description = "Malignant neoplasm of gum"},
            new() {Id = 21, Code = "C03.0", Description = "Upper gum"},
            new() {Id = 22, Code = "C03.1", Description = "Lower gum"},
            new() {Id = 23, Code = "C03.9", Description = "Gum, unspecified"},
            new() {Id = 24, Code = "C04", Description = "Malignant neoplasm of floor of mouth"},
            new() {Id = 25, Code = "C04.0", Description = "Anterior floor of mouth"},
            new() {Id = 26, Code = "C04.1", Description = "Lateral floor of mouth"},
            new() {Id = 27, Code = "C04.8", Description = "Overlapping lesion of floor of mouth"},
            new() {Id = 28, Code = "C04.9", Description = "Floor of mouth, unspecified"},
            new() {Id = 29, Code = "C05", Description = "Malignant neoplasm of palate"},
            new() {Id = 30, Code = "C05.0", Description = "Hard palate"},
            new() {Id = 31, Code = "C05.1", Description = "Soft palate"},
            new() {Id = 32, Code = "C05.2", Description = "Uvula"},
            new() {Id = 33, Code = "C05.8", Description = "Overlapping lesion of palate"},
            new() {Id = 34, Code = "C05.9", Description = "Palate, unspecified"},
            new() {Id = 35, Code = "C06", Description = "Malignant neoplasm of other and unspecified parts of mouth"},
            new() {Id = 36, Code = "C06.0", Description = "Cheek mucosa"},
            new() {Id = 37, Code = "C06.1", Description = "Vestibule of mouth"},
            new() {Id = 38, Code = "C06.2", Description = "Retromolar area"},
            new() {Id = 39, Code = "C06.8", Description = "Overlapping lesion of other and unspecified parts of mouth"},
            new() {Id = 40, Code = "C06.9", Description = "Mouth, unspecified"},
        });
    }
}