namespace DoctorManagmentApp.Infrastructure.Configurations
{
    public class ExternalApi
    {
        public string Uri { get; set; }

        public bool IsAuthenticationRequired { get; set; }

        public AuthApi AuthApi { get; set; }

    }
}