using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Drugs;
using Domain.Entities.UserAccounts;
using Shared.Constants.Module.Consultation;

namespace Domain.Entities.Consultation;

public class Prescription : IBaseId
{
    [Key] public Guid Id { get; set; }
    public string Status { get; set; }
    public int Quantity { get; set; }
    public int Duration { get; set; }
    public DateTime StartDate { get; set; }
    public string Script { get; set; }
    public bool GenericOnly { get; set; }
    public string Instruction1 { get; set; }
    public string Instruction2 { get; set; }
    public string Instruction3 { get; set; }
    public string Instruction4 { get; set; }
    public string AdditionalInstruction { get; set; }
    public string Indication { get; set; } 
    public PrescriptionsConstants.InitiatedEnum Initiated { get; set; } 
    public PrescriptionsConstants.PrescriptionType Type { get; set; } 

    public bool IsActive { get; set; }
    public bool IsInReview { get; set; }
    
    public Drug Drug { get; set; } 
    public int DrugId { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }

    public User AddedBy { get; set; }
    public Guid AddedById { get; set; }
}