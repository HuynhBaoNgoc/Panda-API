using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PandaDomain.Entities
{
    public class PandaFavoriteFood : BaseDataModel
    {
        [ForeignKey(nameof(Panda))]
        public int PandaId { get; set; }
        [ForeignKey(nameof(Food))]
        public int FoodId { get; set; }
        public virtual Panda Panda { get; set; }
        public virtual Food Food { get; set; }
    }
}
