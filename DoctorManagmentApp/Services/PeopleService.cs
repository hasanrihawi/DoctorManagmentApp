using DoctorManagmentApp.Configurations;
using DoctorManagmentApp.Helpers;
using DoctorManagmentApp.Model.Dto;
using DoctorManagmentApp.Services.Interface;
using Microsoft.Extensions.Options;

namespace DoctorManagmentApp.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly ApiHelper<List<Person>> apiHelper;
        private readonly AppSettings appSettings;

        public PeopleService(ApiHelper<List<Person>> apiHelper, IOptions<AppSettings> appSettings)
        {
            this.apiHelper = apiHelper;
            this.appSettings = appSettings.Value;
        }

        public async Task<List<Person>> GetPeople()
        {
            return await apiHelper.GetAsync(appSettings.PeopleApi);
        }
    }
}
