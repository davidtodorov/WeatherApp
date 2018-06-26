using System.Collections.Generic;

namespace Weather.Interfaces.DTOs
{
    public class ForecastDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastDto> DailyForecasts { get; set; }
    }
}
