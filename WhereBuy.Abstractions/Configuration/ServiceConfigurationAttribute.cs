using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Common.Configuration
{
    public class ServiceConfigurationAttribute : Attribute
    {
        public string ConfigurationSection { get; }
        public ServiceConfigurationAttribute(string configurationSection)
         => ConfigurationSection = configurationSection;
    }
}
