using LinqToDB.Configuration;
using LinqToDB;

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
							@"Server=DESKTOP-GP9H7VT;Database=CapExTS;Trusted_Connection=True;Enlist=False;"
					};
			}
		}
	}
}
