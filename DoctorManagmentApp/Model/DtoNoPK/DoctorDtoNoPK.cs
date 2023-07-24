using System.ComponentModel.DataAnnotations;

namespace DoctorManagmentApp.Model.Dto
{
    public class DoctorDtoNoPK
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }

}
