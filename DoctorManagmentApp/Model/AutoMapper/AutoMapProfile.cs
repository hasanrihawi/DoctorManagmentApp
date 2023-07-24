using AutoMapper;
using DoctorManagmentApp.Model.Dto;

namespace DoctorManagmentApp.Model.AutoMapper
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDtoCreate, Appointment>();
            CreateMap<AppointmentDto, Appointment>();


            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDtoCreate, Patient>();
            CreateMap<PatientDto, Patient>();

        }
    }
}
