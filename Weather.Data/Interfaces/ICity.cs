namespace Weather.Data.Interfaces
{
    public interface ICity
    {
        long Id { get; set; }

        string Name { get; set; }

        string Country { get; set; }
    }
}
