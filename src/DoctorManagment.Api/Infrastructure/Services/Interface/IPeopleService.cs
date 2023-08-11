using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagmentApp.Infrastructure.Services.Interface
{
    public interface IPeopleService
    {
        public Task<List<Person>> GetPeople();

    }
}
