using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Entities
{
    public class Food : BaseDataModel
    {
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
    }
}
