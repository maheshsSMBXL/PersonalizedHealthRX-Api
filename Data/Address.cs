namespace PersonalizedHealthRX_Api.Data
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }

        public Guid PatientId { get; set; }

        public State State { get; set; }
    }
}
