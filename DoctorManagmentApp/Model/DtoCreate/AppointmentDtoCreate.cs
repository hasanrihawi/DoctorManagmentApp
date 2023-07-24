using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoctorManagmentApp.Model.Dto
{
    public class AppointmentDtoCreate
    {
        public int PatientID { get; set; }

        public int DoctorID { get; set; }

        public int ClinicID { get; set; }

        [Required]
        public DateTime AppointmentDateTime { get; set; }

        public DateTime? ArrivalDateTime { get; set; }

        public DateTime? CompletionDateTime { get; set; }
    }
}
