namespace DatabaseFirstEFCore.Model
{
    public class PatientDetailsResponse
    {

        public string? Name { get; set; }

        public string? Age { get; set; }

        public string? PhoneNo { get; set; }

        public string? Address { get; set; }

        public string EmailAddress { get; set; } = null!;

        public int PatientId { get; set; }
    }
}
