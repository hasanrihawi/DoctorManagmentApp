using DoctorManagmentApp.Helpers;
using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using DoctorManagmentApp.Configurations;
using Microsoft.Extensions.Options;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/[controller]")]
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

        // GET: api/Patient
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var apiResponse = await apiHelper.CallApiAsync(appSettings.ExternalApi.Uri);
                return Ok(ApiResponse.SuccessResponse(apiResponse));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //var patients = patientService.GetPatients();
            //return Ok(ApiResponse.SuccessResponse(patients));
        }

    }
}
