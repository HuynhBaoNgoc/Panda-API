using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Models.Request
{
    public class UpdateFavoriteFoodRequest
    {
        public int PandaId { get; set; }
        public int FoodId { get;}
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
