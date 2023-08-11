namespace DoctorManagmentApp.Infrastructure.Exceptions
{
    public class ExternalApiRequestException : Exception
    {
        public ExternalApiRequestException(string message) : base(message) { }
    }

}
