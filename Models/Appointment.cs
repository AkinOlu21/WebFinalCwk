using System.Text.Json.Serialization;

namespace WebFinal.Models
{
    public class Appointment
    {

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }

         [JsonIgnore]
        public string? Status { get; set; }
    }
}