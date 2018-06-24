using Weather.Data.Interfaces;

namespace Weather.Data.Models
{
    public class City : ICity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }
}
