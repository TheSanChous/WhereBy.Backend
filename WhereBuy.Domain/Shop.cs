using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Domain
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
    }
}
