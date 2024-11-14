namespace PersonalizedHealthRX_Api.Data
{
    public class DetectedText
    {
        public Guid DetectedTextId { get; set; }
        public string Text { get; set; }
        public float Confidence { get; set; }
        public string Type { get; set; }
    }
}
