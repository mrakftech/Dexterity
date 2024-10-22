﻿using Domain.Entities.Settings.Immunisation;

namespace Services.Features.Settings.Dtos.Immunisations;

public class ImmunisationSetupDto
{
    public ImmunisationSetup Immunisation { get; set; }
    public List<Course> Courses { get; set; }
}