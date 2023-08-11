using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagmentApp.Services.Interface
{
    public interface IPeopleService
    {
        public Task<List<Person>> GetPeople();

    }
}
