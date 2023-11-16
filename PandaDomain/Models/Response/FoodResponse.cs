using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Models.Response
{
    public class FoodResponse
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public double UnitPrice { get; set; }
    }
}
