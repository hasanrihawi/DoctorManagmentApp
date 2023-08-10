using DoctorManagmentApp.Helpers;
using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using DoctorManagmentApp.Configurations;
using Microsoft.Extensions.Options;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExternalApiController : ControllerBase
    {
        private readonly ApiHelper<List<Person>> apiHelper;
        private readonly AppSettings appSettings;

        public ExternalApiController(ApiHelper<List<Person>> apiHelper, IOptions<AppSettings> appSettings)
        {
            this.apiHelper = apiHelper;
            this.appSettings = appSettings.Value;
        }

        // GET: api/v1/GetPeople
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var apiResponse = await apiHelper.CallApiAsync(appSettings.ExternalApi.Uri);
            return Ok(ApiResponse.SuccessResponse(apiResponse));
        }

    }
}
