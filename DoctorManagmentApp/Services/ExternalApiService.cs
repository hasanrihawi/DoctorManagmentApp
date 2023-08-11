using AutoMapper;
using DoctorManagmentApp.Configurations;
using DoctorManagmentApp.Data;
using DoctorManagmentApp.Exceptions;
using DoctorManagmentApp.Helpers;
using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using DoctorManagmentApp.Services.Interface;
using Microsoft.Extensions.Options;

namespace DoctorManagmentApp.Services
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly ApiHelper<List<Person>> apiHelper;

        //private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public ExternalApiService(/*ApplicationDbContext context, */ApiHelper<List<Person>> apiHelper, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.apiHelper = apiHelper;
            //this.context = context;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        public async Task<List<Person>> GetPeople()
        {
            return await apiHelper.CallApiAsync(appSettings.ExternalApi.Uri);
        }
    }
}
