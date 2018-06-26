namespace Weather.Interfaces.DTOs
{
    public class TemperatureDto
    {
        public MetricDto Metric { get; set; }

        public MetricDto Minimum { get; set; }

        public MetricDto Maximum { get; set; }
    }
}
