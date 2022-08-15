namespace Experian.API.Model
{
    public class CityModel : IModel
    {
        public List<CityResult> cities { get; set; }
    }

    public class CityResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
