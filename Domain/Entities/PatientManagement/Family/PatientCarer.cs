﻿namespace Domain.Entities.PatientManagement.Family
{
    public class PatientCarer
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactDetail { get; set; }
        public string RelationshipToPatient { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}