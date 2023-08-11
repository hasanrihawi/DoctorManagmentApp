using DoctorManagmentApp.Model;
using DoctorManagmentApp.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using DoctorManagmentApp.Services.Interface;

namespace DoctorManagmentApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService externalApiService;

        public PeopleController(IPeopleService externalApiService)
        {
            this.externalApiService = externalApiService;
        }

        // GET: api/v1/GetPeople
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            List<Person> apiResponse = await externalApiService.GetPeople();
            return Ok(ApiResponse.SuccessResponse(apiResponse));
        }

    }
}
