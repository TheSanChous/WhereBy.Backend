namespace WhereBuy.Common.Errors
{
    public class AppNotFoundError : AppError
    {
        public AppNotFoundError(int code, string name = null) : base(code, name)
        {
        }

        public string EntityName { get; set; }
        public string Key { get; set; }

        public AppError Create(string entityName, string key)
        {
            EntityName = entityName;
            Key = key;
            return Create($"{EntityName} with key {Key} not found");
        }
    }
}
