using System.Diagnostics.Metrics;

namespace PersonalizedHealthRX_Api.Data
{
    public class State
    {
        public Guid StateId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsSync { get; set; }
        public Country Country { get; set; }
        public bool IsAvFlow { get; set; }
    }
}
