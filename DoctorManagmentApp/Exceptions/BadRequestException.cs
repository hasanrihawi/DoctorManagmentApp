namespace DoctorManagmentApp.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base("Bad request data.") { }
    }

}
