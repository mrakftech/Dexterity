﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Templates;

public class EmailTemplate
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Content { get; set; }
}