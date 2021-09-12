namespace Skinet.Core.Entities.Base
{
    public class Settings
    {
        public AppSettings AppSettings { get; set; }
    }

    public class AppSettings
    {
        public string ConnectionString { get; set; }
    }
}