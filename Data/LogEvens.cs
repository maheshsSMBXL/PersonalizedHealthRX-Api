using System.ComponentModel.DataAnnotations;

namespace PersonalizedHealthRX_Api.Data
{
    public class LogEvents
    {
        [Key]
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
