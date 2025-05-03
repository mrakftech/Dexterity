using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.DrugManagement;

public class Drug
{
    public int Id { get; set; } // Primary Key

    [Required(ErrorMessage = "Trade Name is required")]
    public string TradeName { get; set; } 

    [Required(ErrorMessage = "Generic Name is required")]
    public string GenericName { get; set; } 

    [Required(ErrorMessage = "Manufacture Name is required")]
    public string Manufacture { get; set; } 
    
    public string Ingredients { get; set; }
    public string Barcode { get; set; }
    public string PackType { get; set; }
    public string PackSize { get; set; }
    public string PackSizeMark { get; set; }
    public int MinimumStock { get; set; }
    public string Agent { get; set; }
    public decimal InvoicedCostPrice { get; set; }
    public decimal RetailPrice { get; set; }
    public decimal VAT { get; set; } = 0m; // Default to 0%
    public string Strength { get; set; }
    public decimal CostChange { get; set; }
    public string PackingClass { get; set; }
    public string ProductAuthority { get; set; }
    public decimal FarmPrice { get; set; } = 0.00m;
    public decimal LastPrice { get; set; }
    public string DrugData { get; set; }
    public string Ingredient1 { get; set; }
    public string Ingredient2 { get; set; }
    public string ATC1 { get; set; }
    public string ATC2 { get; set; }
    public bool Discount { get; set; }
    public string CompositionCode { get; set; }
    public string Forms { get; set; }   

    // Optional: Timestamps for record tracking
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}