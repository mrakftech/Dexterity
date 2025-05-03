using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.DrugManagement;

public class DrugStandardScript : BaseEntity
{
    public string PrescriptionType { get; set; }
    public bool SizeAsAllowed { get; set; }
    public int Quantity { get; set; }
    public string ScriptType { get; set; }
    public int DurationDays { get; set; }
    public bool GenericOnly { get; set; }
    public bool IsActive { get; set; }
    public string Instruction1 { get; set; }
    public string Instruction2 { get; set; }
    public string Instruction3 { get; set; }
    public string Instruction4 { get; set; }
    public string Instruction5 { get; set; }

    public StandardScript StandardScript { get; set; }
    public Guid StandardScriptId { get; set; }

    public Drug Drug { get; set; }
   [Range(1, int.MaxValue,ErrorMessage = "Please Select Drug")] public int DrugId { get; set; }
}