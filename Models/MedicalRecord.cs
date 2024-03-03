 using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace WebFinal.Models
{
    public class MedicalRecord
    {

        [Key] public int RecordId { get; set; } //Primary key
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime RecordDate { get; set; }
        
        [JsonIgnore]
        public string? Diagnosis { get; set; }

        [JsonIgnore]
        public string? Prescription { get; set; }
    }
}