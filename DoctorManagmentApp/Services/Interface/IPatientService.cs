using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagmentApp.Services.Interface
{
    public interface IPatientService
    {
        public List<PatientDto> GetPatients();

        public PatientDto GetPatientById(int id);

        public PatientDto CreatePatient(PatientDtoNoPK patient);

        void UpdatePatient(int id, PatientDtoNoPK patient);

        void DeletePatient(int id);
    }
}
