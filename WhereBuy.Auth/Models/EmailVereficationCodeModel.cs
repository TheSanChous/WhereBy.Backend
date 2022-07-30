using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Auth.Models
{
    public class EmailVereficationCodeModel
    {
        public string Email { get; set; }
        public int Code { get; set; }
    }
}
