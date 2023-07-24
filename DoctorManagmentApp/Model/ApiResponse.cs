using DoctorManagmentApp.Model.Dto;
using System.Net;

namespace DoctorManagmentApp.Model
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse()
        {
            Errors = new List<string>();
        }

        public static ApiResponse SuccessResponse()
        {
            return new ApiResponse()
            {
                Success = true
            };
        }

        public static ApiResponse SuccessResponse(object data)
        {
            return new ApiResponse()
            {
                Data = data,
                Success = true
            };
        }

        public static ApiResponse FailResponse()
        {
            return new ApiResponse()
            {
                Success = false
            };
        }

        public static ApiResponse FailResponse(List<string> errors)
        {
            return new ApiResponse()
            {
                Success = false,
                Errors = errors
            };
        }
    }
}
