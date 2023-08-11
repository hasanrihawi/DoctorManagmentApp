using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoctorManagmentApp.Model
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        [Required]
        [ForeignKey("Clinic")]
        public int ClinicID { get; set; }

        [Required]
        public DateTime AppointmentDateTime { get; set; }

        public DateTime? ArrivalDateTime { get; set; }

        public DateTime? CompletionDateTime { get; set; }

        // Navigation properties
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
