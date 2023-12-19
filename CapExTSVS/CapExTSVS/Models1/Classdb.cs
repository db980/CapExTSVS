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

       

        public MySettings(object value)
        {
            MySettings.configdata();
        }

        public IEnumerable<IDataProviderSettings> DataProviders
			=> Enumerable.Empty<IDataProviderSettings>();

		public string DefaultConfiguration => "SqlServer";
		public string DefaultDataProvider => "SqlServer";

        public static string Configuration2 { get; set; }
   
        public IEnumerable<IConnectionStringSettings> ConnectionStrings
		{

           

             get
			{
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "baxy_",//
                        ProviderName = ProviderName.SqlServer,
                        ConnectionString = Configuration2.ToString()
                        //@"Server=DESKTOP-H2DSLGF;Database=CapExTS;Trusted_Connection=True;Enlist=False;TrustServerCertificate=true"
                    };
			}
		}

        public static  void configdata()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // <== compile failing here
                .AddJsonFile("appsettings.json");

            var Configuration = builder.Build();
             Configuration2 = Configuration.GetConnectionString("DefaultConnection");
            //Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
