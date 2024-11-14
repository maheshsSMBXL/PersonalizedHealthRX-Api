namespace PersonalizedHealthRX_Api.Data
{
    public class DriverLicense
    {
        public Guid DriverLicenseId { get; set; }
        public Guid FileId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string MimeType { get; set; }
        public string Url { get; set; }
        public string UrlThumbnail { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid PatientId { get; set; }

        public Metadata Metadata { get; set; }
    }
}
