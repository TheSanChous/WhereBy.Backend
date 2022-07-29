using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Common.Configuration
{
    [ServiceConfiguration("Database")]
    public class DatabaseConfiguration
    {
        public string DefaultConnection { get; set; }
        public string LocalConnection { get; set; }
    }
}
