﻿using Domain.Entities.Settings.Consultation.Immunisation;

namespace Services.Features.Settings.Dtos.Immunisations
{
    public class ShotDto
    {
        public Shot Shot { get; set; }
        public List<Batch> BatchDetails { get; set; }
    }
}
