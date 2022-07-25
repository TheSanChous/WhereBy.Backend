using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBy.Application.Configuration
{
    public class MailConfiguration
    {
        public static string ConfigurationSection = "Mail";

        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool UseSsl { get; set; }
    }
}
