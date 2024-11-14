using System.Net;

namespace PersonalizedHealthRX_Api.Data
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public Guid PartnerId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Metadata { get; set; } // You can use a JSON field or separate entity
        public string Email { get; set; }
        public float Weight { get; set; }
        public string BloodPressure { get; set; }
        public float Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string GenderLabel { get; set; }
        public bool Active { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public string CurrentMedications { get; set; }
        public string MedicalConditions { get; set; }
        public string Allergies { get; set; }
        public bool Pregnancy { get; set; }
        public string Ssn { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsLive { get; set; }
        public Guid? ExamId { get; set; }
        public Guid? RecentEncounterId { get; set; }
        public Guid? ImportantOfferingCaseId { get; set; }
        public Guid? ClinicianId { get; set; }
        public DriverLicense DriverLicense { get; set; }
        public Address Address { get; set; }
        public string AuthLink { get; set; }
    }
}
