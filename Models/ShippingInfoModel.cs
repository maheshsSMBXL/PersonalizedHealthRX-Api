namespace PersonalizedHealthRX_Api.Models
{
    public class ShippingInfoModel
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? phoneNumber { get; set; }
        public string? addressline1 { get; set; }
        public string? addressline2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zipcode { get; set; }
        public bool? prefilldetialsStatues { get; set; }
    }
}
