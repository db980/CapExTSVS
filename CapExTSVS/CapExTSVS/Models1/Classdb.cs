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

		//IConfigurationRoot configuration = new ConfigurationBuilder()
		//   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
		//   .AddJsonFile("appsettings.json").Build();
		//public static IConfiguration Configuration { get; private set; }


		//string conStr1 = new  ConfigurationBuilder().Build().GetSection("ConnectionStrings:DefaultConnection").Value;

		public IEnumerable<IConnectionStringSettings> ConnectionStrings
		{
			get
			{
				yield return
					new ConnectionStringSettings
					{
						Name = "CapExTS",
						ProviderName = ProviderName.SqlServer,
						ConnectionString =
                            @"Server=DESKTOP-H2DSLGF;Database=CapExTS;Trusted_Connection=True;Enlist=False;TrustServerCertificate=true"
                    };
			}
		}
	}
}
