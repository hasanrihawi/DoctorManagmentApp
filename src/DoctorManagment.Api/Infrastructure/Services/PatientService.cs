using AutoMapper;
using DoctorManagmentApp.Data;
using DoctorManagmentApp.Infrastructure.Exceptions;
using DoctorManagmentApp.Infrastructure.Services.Interface;
using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;

namespace DoctorManagmentApp.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PatientService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<PatientDto> GetPatients()
        {
            return context.Patients.Select(p => mapper.Map<PatientDto>(p)).ToList();
        }

        public PatientDto GetPatientById(int id)
        {
            var patient = context.Patients.Find(id);
            return patient == null ? null : mapper.Map<PatientDto>(patient);
        }

        public PatientDto CreatePatient(PatientDtoNoPK patient)
        {
            var mappedPatient = mapper.Map<Patient>(patient);
            context.Patients.Add(mappedPatient);
            context.SaveChanges();
            return mapper.Map<PatientDto>(mappedPatient);
        }

        public void UpdatePatient(int id, PatientDtoNoPK patient)
        {
            var existingPatient = context.Patients.Find(id);
            if (existingPatient == null)
                throw new NotFoundException();

            mapper.Map(patient, existingPatient);
            context.SaveChanges();
        }

        public void DeletePatient(int id)
        {
            var patient = context.Patients.Find(id);
            if (patient == null)
                throw new NotFoundException();

            context.Patients.Remove(patient);
            context.SaveChanges();
        }
    }
}
