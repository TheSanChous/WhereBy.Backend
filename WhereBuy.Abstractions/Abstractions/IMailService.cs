﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Common.Abstractions
{
    public interface IMailService
    {
        public Task SendCodeAsync(string to, long code);
    }
}
