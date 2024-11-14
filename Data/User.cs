using System.ComponentModel.DataAnnotations;

namespace PersonalizedHealthRX_Api.Data
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? VoucherId { get; set; }
        public string? CaseId { get; set; }
        public string? AuthLink { get; set; }
    }
}
