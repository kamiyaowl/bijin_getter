using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace bijin_getter {
	class Program {
		static void Main(string[] args) {
			var areas = new string[]{
				"jp",
				"2012jp",
				"2011jp",
				"hokkaido",
				"aomori",
				"iwate",
				"sendai",
				"akita",
				"ibaraki",
				"tochigi",
				"gunma",
				"saitama",
				"chiba",
				"tokyo",
				"niigata",
				"kanazawa",
				"fukui",
				"yamanashi",
				"nagano",
				"shizuoka",
				"nagoya",
				"kyoto",
				"osaka",
				"kobe",
				"nara",
				"tottori",
				"okayama",
				"hiroshima",
				"yamaguchi",
				"kagawa",
				"fukuoka",
				"saga",
				"kumamoto",
				"miyazaki",
				"kagoshima",
				"okinawa",
				"taiwan",
				"hawaii",
			};

			const string baseUrl = @"http://www.bijint.com/{0}/tokei_images/{1:00}{2:00}.jpg";
			const string basePath = @"{0}/{1:00}{2:00}.jpg";

			Console.WriteLine("===== Start =====");
			Parallel.ForEach(areas, name => {
				if (!Directory.Exists(name)) {
					Directory.CreateDirectory(name);
				}
				foreach (var h in Enumerable.Range(0, 24)) {
					foreach (var m in Enumerable.Range(0, 60)) {
						var getUrl = string.Format(baseUrl, name, h, m);
						var getPath = string.Format(basePath, name, h, m);
						Console.WriteLine("{0} -> {1}", getUrl, getPath);
						try {
							new WebClient().DownloadFile(getUrl, getPath);
						} catch (Exception ex) {
							//適当に握りつぶす
							Console.WriteLine(ex.Message);
						}
					}
				}
			});
			Console.WriteLine("===== Complete =====");
			Console.ReadLine();
		}
	}
}
