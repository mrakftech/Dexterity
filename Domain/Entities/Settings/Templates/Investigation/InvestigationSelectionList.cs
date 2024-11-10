﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Templates.Investigation
{
    public class InvestigationSelectionList
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Required")] public string Name { get; set; }

        public ICollection<InvestigationSelectionValue> InvestigationSelectionValues { get; set; }
    }
}