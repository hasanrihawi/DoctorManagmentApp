namespace DoctorManagmentApp.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("Bad request data.") { }
    }

}
