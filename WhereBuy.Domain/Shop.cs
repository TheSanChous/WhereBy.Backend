using System;

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
