using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Models.Request
{
    public class AddFoodRequest
    {
        public string FoodName { get; set; }
        public double UnitPrice { get; set; }
    }
}
