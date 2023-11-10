using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PandaDomain.Entities
{
    [Table(nameof(Panda))]
    public class Panda : BaseDataModel
    {
        [Key]
        public int PandaId { get; set; }
        public string PandaName { get; set; }
        [ForeignKey(nameof(Entities.City))]
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
