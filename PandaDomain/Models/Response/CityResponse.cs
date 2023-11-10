using PandaDomain.Entities;

namespace PandaDomain.Models.Response
{
    public class CityResponse : BaseDataModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
