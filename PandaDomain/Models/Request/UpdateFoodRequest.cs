using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Models.Request
{
    public class UpdateFoodRequest
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
