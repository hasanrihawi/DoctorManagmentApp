using System.ComponentModel.DataAnnotations;

namespace DoctorManagmentApp.Model
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public List<Appointment> Appointments { get; set; }

    }

}
