namespace PersonalizedHealthRX_Api.Data
{
    public class Metadata
    {
        public Guid MetadataId { get; set; }
        public bool DriverLicense { get; set; }
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
        public bool DateOfBirth { get; set; }
        public bool Sex { get; set; }
        public bool SexWord { get; set; }
        public ICollection<DetectedText> DetectedTexts { get; set; }
    }
}
