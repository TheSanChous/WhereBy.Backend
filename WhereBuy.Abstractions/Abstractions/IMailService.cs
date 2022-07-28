namespace WhereBuy.Common.Abstractions
{
    public interface IMailService
    {
        public Task SendCodeAsync(string to, long code);
    }
}
