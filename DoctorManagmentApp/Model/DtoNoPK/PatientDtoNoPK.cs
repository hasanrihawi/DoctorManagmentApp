using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace DoctorManagmentApp.Model.Dto
{
    public class PatientDtoNoPK
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }

    public class PatientDtoNoPKValidator : AbstractValidator<PatientDtoNoPK>
    {
        public PatientDtoNoPKValidator()
        {
            RuleFor(x => x.Name).MinimumLength(8);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.DateOfBirth).NotNull();
        }
    }

}
