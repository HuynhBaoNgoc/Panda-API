using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PandaDomain.Entities
{
    [Table(nameof(City))]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<Panda> Pandas { get; set; }
    }
}
