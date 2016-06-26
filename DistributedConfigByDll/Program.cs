using System;
using System.Linq;
using System.Configuration;

namespace DistributedConfigByDll
{
	class Program
	{
		static void Main(string[] args)
		{
			var AppConfig = GetConfiguration(@"App.config");
			var pAConfig = GetConfiguration(@"ProjectA.config");
			var pBConfig = GetConfiguration(@"ProjectB.config");


			var configs = new[] { AppConfig, pAConfig, pBConfig };
			var a = configs.SelectMany(x => x.Sections.OfType<ConfigurationSection>())
				.OrderBy(section=>section.SectionInformation.Name)
				.GroupBy(section => section.SectionInformation.Name)
				.Select(g =>
				{
					Console.WriteLine(g.Key);
					var z = g.ToList();
					return "dummy";
				}).ToList();

			var pag = pAConfig.GetSection("pageAppearanceGroup");
			var hmm = pAConfig.GetSection("notexisting");
			Console.WriteLine("AppConfig: " + AppConfig.AppSettings.Settings["main"].Value);
			Console.WriteLine("A: " + pAConfig.AppSettings.Settings["ProjectA"].Value);
			Console.WriteLine("B: " + pBConfig.AppSettings.Settings["ProjectB"].Value);

			Console.ReadKey();
		}

		private static Configuration GetConfiguration(string fileConfig)
		{
			ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
			fileMap.ExeConfigFilename = fileConfig;  // relative path names possible
			return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None, true);
		}
	}
}
