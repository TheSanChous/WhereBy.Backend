using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBy.Application.Interfaces
{
    public interface IMailService
    {
        public Task SendCodeAsync(string to, long code);
    }
}
