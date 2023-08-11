using AutoMapper;
using DoctorManagmentApp.Model.Dto;

namespace DoctorManagmentApp.Model.AutoMapper
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDtoNoPK, Appointment>();
            CreateMap<AppointmentDto, Appointment>();


            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDtoNoPK, Patient>();
            CreateMap<PatientDto, Patient>();

            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDtoNoPK, Doctor>();
            CreateMap<DoctorDto, Doctor>();

        }
    }
}
