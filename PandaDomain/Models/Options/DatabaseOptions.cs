using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDomain.Models.Options
{
    public class DatabaseOptions
    {
        //public static string JsonKey => nameof(DatabaseOptions);

        public string Server { get; set; }

        public string Port { get; set; }

        public string Database { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string Options { get; set; }
    }
}
