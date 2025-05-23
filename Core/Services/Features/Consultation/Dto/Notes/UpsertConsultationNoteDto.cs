﻿using System.ComponentModel.DataAnnotations;
using Services.State;
using Shared.Constants.Module.Consultation;

namespace Services.Features.Consultation.Dto.Notes;

public class UpsertConsultationNoteDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string Status { get; set; } = NotesStatus.None;
    public bool IsPastHistory { get; set; }
    public bool IsFamilyHistory { get; set; }
    public bool IsActiveCondition { get; set; }
    public bool IsSocialHistory { get; set; }
    public bool IsPrivate { get; set; }
    public Guid HcpId { get; set; } = ApplicationState.Auth.CurrentUser.UserId;
    public Guid PatientId { get; set; } = ApplicationState.GetSelectPatientId();
    [Required] public string Notes { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Please Select code")]
    public int HealthCodeId { get; set; }
}