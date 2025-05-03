using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities.Settings.DrugManagement;

namespace Domain.Entities.Settings.Consultation.Immunisation
{
    public class Batch : IBaseId
    {
        [Key]
        public Guid Id { get; set; }
        public string BatchNumber { get; set; }
        public DateTime Expiry { get; set; }
        public string TradeName { get; set; }
        public string ManfactureName { get; set; }
        public int BatchCount { get; set; }
        public int Remaining { get; set; }
        public bool IsActive { get; set; }
        public bool BatchCompleteWhenZero { get; set; }

        public int DrugId { get; set; }
        public Drug Drug { get; set; }
    }
}