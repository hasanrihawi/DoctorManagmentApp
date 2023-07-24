using AutoMapper;
using DoctorManagmentApp.Data;
using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using DoctorManagmentApp.Services.Interface;

namespace DoctorManagmentApp.Services
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

        public PatientDto CreatePatient(PatientDtoCreate patient)
        {
            var mappedPatient = mapper.Map<Patient>(patient);
            context.Patients.Add(mappedPatient);
            context.SaveChanges();
            return mapper.Map<PatientDto>(mappedPatient);
        }

        public bool UpdatePatient(int id, PatientDto patient)
        {
            var existingPatient = context.Patients.Find(id);
            if (existingPatient == null)
                return false;

            mapper.Map(patient, existingPatient);
            context.SaveChanges();

            return true;
        }

        public bool DeletePatient(int id)
        {
            var patient = context.Patients.Find(id);
            if (patient == null)
                return false;

            context.Patients.Remove(patient);
            context.SaveChanges();
            return true;
        }
    }
}
