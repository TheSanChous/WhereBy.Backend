using System;

namespace WhereBuy.Domain
{
    public class Notice
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Created { get; set; } = String.Empty;
        public string Modified { get; set; } = String.Empty;
        public string Deleted { get; set; } = null;
    }
}
