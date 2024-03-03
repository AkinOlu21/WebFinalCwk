using System.Text.Json.Serialization;

namespace WebFinal.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
                
        [JsonIgnore]
        public string? MedicalHistory { get; set; }
    }
}