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

        public virtual AppError Create(string name)
        {
            return new AppError(Code, name);
        }
    }
}
