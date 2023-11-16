using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Models.Request
{
    public class AddFavoriteFoodRequest
    {
        public int PandaId { get; set; }
        public int FoodId { get; }
    }
}
