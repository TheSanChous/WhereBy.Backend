namespace WhereBuy.Common.Errors
{
    public class AppEntityExistsError : AppError
    {
        public AppEntityExistsError(int code, string name = null) : base(code, name)
        {
        }

        public string EntityName { get; set; }

        public virtual AppError Create(string entityName)
        {
            EntityName = entityName;
            return base.Create($"{entityName} alrerady exists");
        }
    }
}
