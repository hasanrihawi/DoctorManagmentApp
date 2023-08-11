using DoctorManagmentApp.Infrastructure.Configurations;
using DoctorManagmentApp.Infrastructure.Helpers;
using DoctorManagmentApp.Infrastructure.Services.Interface;
using DoctorManagmentApp.Model.Dto;
using Microsoft.Extensions.Options;

namespace DoctorManagmentApp.Infrastructure.Services
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
