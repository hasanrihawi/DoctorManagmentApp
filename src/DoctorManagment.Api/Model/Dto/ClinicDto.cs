using System.ComponentModel.DataAnnotations;

namespace DoctorManagmentApp.Model.Dto
{
    public class ClinicDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
