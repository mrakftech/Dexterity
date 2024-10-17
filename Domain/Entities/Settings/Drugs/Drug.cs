using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Drugs;

public class Drug
{
    public int Id { get; set; } // Primary Key

    [Required(ErrorMessage = "Trade Name is required")] public string TradeName { get; set; } // Trade Name
    public string AmFam { get; set; } // Drug Family or Classification
    public string Barcode { get; set; } // Barcode
    [Required(ErrorMessage = "Generic Name is required")] public string GenericName { get; set; } // Generic Name
    [Required(ErrorMessage = "Manufacture Name is required")] public string Manufacture { get; set; } // Generic Name
    public string Category { get; set; } // Category (Dropdown)
    public int PackSize { get; set; } // Pack Size
    public string PackSizeName { get; set; } // Pack Size Name
    public string PackSizeUnits { get; set; } // Pack Size Units
    public string NoteAutUse { get; set; } // Notes or Authorization
    public string Agent { get; set; } // Manufacturer or Agent
    public decimal IngredientCostPrice { get; set; } // Ingredient Cost Price
    public decimal MaxRrp { get; set; } // Max Recommended Retail Price
    public decimal Vat { get; set; } // Value Added Tax Rate
    public string Strength { get; set; } // Strength

    public string GasCharge { get; set; } // Gas Charge
    public string PoisonClass { get; set; } // Poison Class
    public string ProductAuthortext { get; set; } // Product Authorization
    public decimal ItemPrice { get; set; } // Item Price
    public string UomSize { get; set; } // Unit of Measure/Size
    public string DrugCats { get; set; } // Drug Categories
    public string Warnings { get; set; } // Warnings
    public string Ingrd1 { get; set; } // Ingredient 1
    public string Ingrd2 { get; set; } // Ingredient 2
    public string Atc1 { get; set; } // ATC Code 1
    public string Atc2 { get; set; } // ATC Code 2
    public bool Dentist { get; set; } // Checkbox for Dentist
    public string ColourCode { get; set; } // Colour Code
    public string Form { get; set; } // Form (e.g., tablet, liquid)

    // Optional: Timestamps for record tracking
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}