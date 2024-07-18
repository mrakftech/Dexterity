namespace Services.Configurations
{
    public class MailConfiguration
    {
        public string From { get; set; } = "support@automatingrevenuecycles.com";
        public string Host { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
        public string UserName { get; set; } = "support@automatingrevenuecycles.com";
        public string Password { get; set; } = "sesyuqxkzmiyqeva";
        public string DisplayName { get; set; } = "arc Support";
    }
}