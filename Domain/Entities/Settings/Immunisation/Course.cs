﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Immunisation;

public class Course
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    public bool IsActive { get; set; }
}