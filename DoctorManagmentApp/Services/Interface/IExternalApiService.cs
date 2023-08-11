using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagmentApp.Services.Interface
{
    public interface IExternalApiService
    {
        public Task<List<Person>> GetPeople();

    }
}
