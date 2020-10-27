using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    public static class json
	{


		
		public static void savejson(Player player, string savepath)
		{

			string jsonfile = Newtonsoft.Json.JsonConvert.SerializeObject(player);
			System.IO.File.WriteAllText(savepath, jsonfile);

		}

			public static bool loaddata(string loadpath , out Player player) {

			try
			{
				string jsonf = System.IO.File.ReadAllText(loadpath);
				player = Newtonsoft.Json.JsonConvert.DeserializeObject<Player> ( jsonf );
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine("JsonFile not Found");
				player = null;
				return false;
			
			}
		
		}
	}
}
