using System.ComponentModel.DataAnnotations;

namespace PersonalizedHealthRX_Api.Data
{
    public class LoggedWebHookData
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }
    }
}
