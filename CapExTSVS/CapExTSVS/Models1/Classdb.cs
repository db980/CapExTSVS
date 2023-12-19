using LinqToDB.Configuration;
using LinqToDB;
using LinqToDB.Common;

namespace CapExTSVS.Models1
{
	public class ConnectionStringSettings : IConnectionStringSettings
	{
		public string ConnectionString { get; set; }
		public string Name { get; set; }
		public string ProviderName { get; set; }
		public bool IsGlobal => false;
	}

	public class MySettings : ILinqToDBSettings
	{

		public IEnumerable<IDataProviderSettings> DataProviders
			=> Enumerable.Empty<IDataProviderSettings>();

		public string DefaultConfiguration => "SqlServer";
		public string DefaultDataProvider => "SqlServer";

		IConfigurationRoot configuration = new ConfigurationBuilder()
		   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
		   .AddJsonFile("appsettings.json").Build();
		//public static IConfiguration Configuration { get; private set; }


		//string conStr1 = new  ConfigurationBuilder().Build().GetSection("ConnectionStrings:DefaultConnection").Value;


		//public static string conStr1 { get; }

		//    var configurationBuilder = new ConfigurationBuilder();
		//    string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
		//    configurationBuilder.AddJsonFile(path, false);
		//    conStr1 = configurationBuilder.Build().GetSection("ConnectionStrings:ConStr1").Value;


		public IEnumerable<IConnectionStringSettings> ConnectionStrings
		{
			get
			{
				yield return
					new ConnectionStringSettings
					{
						Name = "CapExTS",
						ProviderName = ProviderName.SqlServer,
						ConnectionString = configuration.ToString()
                            //@"Server=DESKTOP-H2DSLGF;Database=CapExTS;Trusted_Connection=True;Enlist=False;TrustServerCertificate=true"
                    };
			}
		}
	}
}
