﻿using System.ComponentModel.DataAnnotations;

namespace DoctorManagmentApp.Model.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }

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
}
