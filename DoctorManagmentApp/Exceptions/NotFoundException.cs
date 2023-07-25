namespace DoctorManagmentApp.Exceptions
{
    // Custom exceptions for different types of errors (optional).
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("The requested resource was not found.") { }
    }

}
