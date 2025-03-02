﻿using Domain.Contracts;
using Domain.Entities.Consultation.Detail;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Consultation.Immunisations;

public class AdministerShot : IBaseId
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DueDate { get; set; }
    public DateTime? GivenDate { get; set; }
    public string Side { get; set; }
    public bool IsGiven { get; set; }
    public bool IsDue { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsFirstShot { get; set; }

    public User Hcp { get; set; }
    public Guid? HcpId { get; set; }

    public ImmunisationSchedule ImmunisationSchedule { get; set; }
    public Guid? ImmunisationScheduleId { get; set; }

    public ShotBatch ShotBatch { get; set; }
    public Guid? ShotBatchId { get; set; }

    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
}