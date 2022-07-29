namespace WhereBuy.Common.Configuration
{
    [ServiceConfiguration("Mail")]
    public class MailConfiguration
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool UseSsl { get; set; }
    }
}
