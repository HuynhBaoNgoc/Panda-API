using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Models.Request
{
    public class UpdatePandaRequest
    {
        public int PandaId { get; set; }
        public string PandaName { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
