namespace PandaDomain.Models.Request
{
    public class UpdateCityRequest
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
