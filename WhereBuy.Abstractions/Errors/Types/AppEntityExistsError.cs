using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Common.Errors
{
    public class AppEntityExistsError : AppError
    {
        public AppEntityExistsError(int code, string name = null) : base(code, name)
        {
        }

        public string EntityName { get; set; }

        public AppError Create(string entityName)
        {
            EntityName = entityName;
            return Create($"{EntityName} alrerady exists");
        }
    }
}
