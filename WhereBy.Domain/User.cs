using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBy.Domain
{
    public class User : IdentityUser
    {
        public int Points { get; set; }
    }
}
