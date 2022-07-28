using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Common.Errors
{
    public class AppError : Exception
    {
        public AppError(int code, string name = null)
         : base(name)
        {
            Code = code;
            Name = name;
        }

        public int Code { get; set; }
        public string Name { get; set; }

        public AppError Create(string name)
        {
            return new AppError(Code, name);
        }
    }
}
