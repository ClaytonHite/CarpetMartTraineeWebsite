namespace WebsiteProjectCarpetMart
{
	public class Config
	{
        private static IConfiguration _configuration;
        public static void Initialize()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }
        public static string GetConnectionString(string db)
        {
            return _configuration.GetValue<string>($"ConnectionStrings:{db}");
        }
    }
}
