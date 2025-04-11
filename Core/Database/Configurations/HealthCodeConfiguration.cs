using Domain.Entities.Settings.Consultation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

public class HealthCodeConfiguration : IEntityTypeConfiguration<HealthCode>
{
    public void Configure(EntityTypeBuilder<HealthCode> builder)
    {
        builder.HasData(new List<HealthCode>()
        {
            new()
            {
                Id = 1, Code = "A01", Chapter = "General and Unspecified", Description = "Pain general/multiple sites"
            },
            new() {Id = 2, Code = "A02", Chapter = "General and Unspecified", Description = "Chills"},
            new() {Id = 3, Code = "A03", Chapter = "General and Unspecified", Description = "Fever"},
            new()
            {
                Id = 4, Code = "A04", Chapter = "General and Unspecified", Description = "Weakness/tiredness general"
            },
            new() {Id = 5, Code = "A05", Chapter = "General and Unspecified", Description = "Feeling ill"},
            new() {Id = 6, Code = "A06", Chapter = "General and Unspecified", Description = "Fainting/syncope"},
            new() {Id = 7, Code = "A07", Chapter = "General and Unspecified", Description = "Coma"},
            new() {Id = 8, Code = "A08", Chapter = "General and Unspecified", Description = "Swelling"},
            new() {Id = 9, Code = "A09", Chapter = "General and Unspecified", Description = "Sweating problem"},
            new()
            {
                Id = 10, Code = "A10", Chapter = "General and Unspecified", Description = "Bleeding/haemorrhage NOS"
            },
            new() {Id = 11, Code = "A11", Chapter = "General and Unspecified", Description = "Chest pain NOS"},
            new()
            {
                Id = 12, Code = "A13", Chapter = "General and Unspecified",
                Description = "Concern/fear medical treatment"
            },
            new() {Id = 13, Code = "A16", Chapter = "General and Unspecified", Description = "Irritable infant"},
            new()
            {
                Id = 14, Code = "A18", Chapter = "General and Unspecified", Description = "Concern about appearance"
            },
            new()
            {
                Id = 15, Code = "A20", Chapter = "General and Unspecified",
                Description = "Euthanasia request/discussion"
            },
            new()
            {
                Id = 16, Code = "A21", Chapter = "General and Unspecified", Description = "Risk factor for malignancy"
            },
            new() {Id = 17, Code = "A23", Chapter = "General and Unspecified", Description = "Risk factor NOS"},
            new() {Id = 18, Code = "A25", Chapter = "General and Unspecified", Description = "Fear of death/dying"},
            new() {Id = 19, Code = "A26", Chapter = "General and Unspecified", Description = "Fear of cancer NOS"},
            new()
            {
                Id = 20, Code = "A27", Chapter = "General and Unspecified", Description = "Fear of other disease NOS"
            },
            new()
            {
                Id = 21, Code = "A28", Chapter = "General and Unspecified",
                Description = "Limited function/disability NOS"
            },
            new()
            {
                Id = 22, Code = "A29", Chapter = "General and Unspecified",
                Description = "General symptom/complaint other"
            },
            new() {Id = 23, Code = "A70", Chapter = "General and Unspecified", Description = "Tuberculosis"},
            new() {Id = 24, Code = "A71", Chapter = "General and Unspecified", Description = "Measles"},
            new() {Id = 25, Code = "A72", Chapter = "General and Unspecified", Description = "Chickenpox"},
            new() {Id = 26, Code = "A73", Chapter = "General and Unspecified", Description = "Malaria"},
            new() {Id = 27, Code = "A74", Chapter = "General and Unspecified", Description = "Rubella"},
            new()
            {
                Id = 28, Code = "A75", Chapter = "General and Unspecified", Description = "Infectious mononucleosis"
            },
            new() {Id = 29, Code = "A76", Chapter = "General and Unspecified", Description = "Viral exanthem other"},
            new() {Id = 30, Code = "A77", Chapter = "General and Unspecified", Description = "Viral disease other/NOS"},
            new()
            {
                Id = 31, Code = "A78", Chapter = "General and Unspecified", Description = "Infectious disease other/NOS"
            },
            new() {Id = 32, Code = "A79", Chapter = "General and Unspecified", Description = "Malignancy NOS"},
            new() {Id = 33, Code = "A80", Chapter = "General and Unspecified", Description = "Trauma/injury NOS"},
            new()
            {
                Id = 34, Code = "A81", Chapter = "General and Unspecified", Description = "Multiple trauma/injuries"
            },
            new()
            {
                Id = 35, Code = "A82", Chapter = "General and Unspecified", Description = "Secondary effect of trauma"
            },
            new()
            {
                Id = 36, Code = "A84", Chapter = "General and Unspecified", Description = "Poisoning by medical agent"
            },
            new()
            {
                Id = 37, Code = "A85", Chapter = "General and Unspecified", Description = "Adverse effect medical agent"
            },
            new()
            {
                Id = 38, Code = "A86", Chapter = "General and Unspecified",
                Description = "Toxic effect non-medicinal substance"
            },
            new()
            {
                Id = 39, Code = "A87", Chapter = "General and Unspecified",
                Description = "Complication of medical treatment"
            },
            new()
            {
                Id = 40, Code = "A88", Chapter = "General and Unspecified",
                Description = "Adverse effect physical factor"
            },
            new()
            {
                Id = 41, Code = "A89", Chapter = "General and Unspecified", Description = "Effect prosthetic device"
            },
            new()
            {
                Id = 42, Code = "A90", Chapter = "General and Unspecified",
                Description = "Congenital anomaly OS/multiple"
            },
            new()
            {
                Id = 43, Code = "A91", Chapter = "General and Unspecified",
                Description = "Abnormal result investigation NOS"
            },
            new()
            {
                Id = 44, Code = "A92", Chapter = "General and Unspecified",
                Description = "Allergy/allergic reaction NOS"
            },
            new() {Id = 45, Code = "A93", Chapter = "General and Unspecified", Description = "Premature newborn"},
            new()
            {
                Id = 46, Code = "A94", Chapter = "General and Unspecified", Description = "Perinatal morbidity other"
            },
            new() {Id = 47, Code = "A95", Chapter = "General and Unspecified", Description = "Perinatal mortality"},
            new() {Id = 48, Code = "A96", Chapter = "General and Unspecified", Description = "Death"},
            new() {Id = 49, Code = "A97", Chapter = "General and Unspecified", Description = "No disease"},
            new()
            {
                Id = 50, Code = "A98", Chapter = "General and Unspecified",
                Description = "Health maintenance/prevention"
            },
            new() {Id = 51, Code = "A99", Chapter = "General and Unspecified", Description = "General disease NOS"},
            new() {Id = 55, Code = "R01", Chapter = "Respiratory", Description = "Pain respiratory system"},
            new() {Id = 56, Code = "R02", Chapter = "Respiratory", Description = "Shortness of breath/dyspnoea"},
            new() {Id = 57, Code = "R03", Chapter = "Respiratory", Description = "Wheezing"},
            new() {Id = 58, Code = "R04", Chapter = "Respiratory", Description = "Breathing problem, other"},
            new() {Id = 59, Code = "R05", Chapter = "Respiratory", Description = "Cough"},
            new() {Id = 60, Code = "R06", Chapter = "Respiratory", Description = "Nose bleed/epistaxis"},
            new() {Id = 61, Code = "R07", Chapter = "Respiratory", Description = "Sneezing/nasal congestion"},
            new() {Id = 62, Code = "R08", Chapter = "Respiratory", Description = "Nose symptom/complaint other"},
            new() {Id = 63, Code = "R09", Chapter = "Respiratory", Description = "Sinus symptom/complaint"},
            new() {Id = 64, Code = "R21", Chapter = "Respiratory", Description = "Throat symptom/complaint"},
            new() {Id = 65, Code = "R23", Chapter = "Respiratory", Description = "Voice symptom/complaint"},
            new() {Id = 66, Code = "R24", Chapter = "Respiratory", Description = "Haemoptysis"},
            new() {Id = 67, Code = "R25", Chapter = "Respiratory", Description = "Sputum/phlegm abnormal"},
            new() {Id = 68, Code = "R26", Chapter = "Respiratory", Description = "Fear of cancer respiratory system"},
            new() {Id = 69, Code = "R27", Chapter = "Respiratory", Description = "Fear of respiratory disease, other"},
            new() {Id = 70, Code = "R28", Chapter = "Respiratory", Description = "Limited function/disability (r)"},
            new() {Id = 71, Code = "R29", Chapter = "Respiratory", Description = "Respiratory symptom/complaint oth."},
            new() {Id = 72, Code = "R71", Chapter = "Respiratory", Description = "Whooping cough"},
            new() {Id = 73, Code = "R72", Chapter = "Respiratory", Description = "Strep throat"},
            new() {Id = 74, Code = "R73", Chapter = "Respiratory", Description = "Boil/abscess nose"},
            new() {Id = 75, Code = "R74", Chapter = "Respiratory", Description = "Upper respiratory infection acute"},
            new() {Id = 76, Code = "R75", Chapter = "Respiratory", Description = "Sinusitis acute/chronic"},
            new() {Id = 77, Code = "R76", Chapter = "Respiratory", Description = "Tonsillitis acute"},
            new() {Id = 78, Code = "R77", Chapter = "Respiratory", Description = "Laryngitis/tracheitis acute"},
            new() {Id = 79, Code = "R78", Chapter = "Respiratory", Description = "Acute bronchitis/bronchiolitis"},
            new() {Id = 80, Code = "R79", Chapter = "Respiratory", Description = "Chronic bronchitis"},
            new() {Id = 81, Code = "R80", Chapter = "Respiratory", Description = "Influenza"},
            new() {Id = 82, Code = "R81", Chapter = "Respiratory", Description = "Pneumonia"},
            new() {Id = 83, Code = "R82", Chapter = "Respiratory", Description = "Pleurisy/pleural effusion"},
            new() {Id = 84, Code = "R83", Chapter = "Respiratory", Description = "Respiratory infection other"},
            new() {Id = 85, Code = "R84", Chapter = "Respiratory", Description = "Malignant neoplasm bronchus/lung"},
            new()
            {
                Id = 86, Code = "R85", Chapter = "Respiratory", Description = "Malignant neoplasm respiratory, other"
            },
            new() {Id = 87, Code = "R86", Chapter = "Respiratory", Description = "Benign neoplasm respiratory"},
            new() {Id = 88, Code = "R87", Chapter = "Respiratory", Description = "Foreign body nose/larynx/bronch"},
            new() {Id = 89, Code = "R88", Chapter = "Respiratory", Description = "Injury respiratory other"},
            new() {Id = 90, Code = "R89", Chapter = "Respiratory", Description = "Congenital anomaly respiratory"},
            new() {Id = 91, Code = "R90", Chapter = "Respiratory", Description = "Hypertrophy tonsils/adenoids"},
            new() {Id = 92, Code = "R92", Chapter = "Respiratory", Description = "Neoplasm respiratory unspecified"},
            new() {Id = 93, Code = "R95", Chapter = "Respiratory", Description = "Chronic obstructive pulmonary dis"},
            new() {Id = 94, Code = "R96", Chapter = "Respiratory", Description = "Asthma"},
            new() {Id = 95, Code = "R97", Chapter = "Respiratory", Description = "Allergic rhinitis"},
            new() {Id = 96, Code = "R98", Chapter = "Respiratory", Description = "Hyperventilation syndrome"},
            new() {Id = 97, Code = "R99", Chapter = "Respiratory", Description = "Respiratory disease other"},
        });
    }
}