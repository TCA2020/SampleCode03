using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			string currentDirectory = System.IO.Directory.GetCurrentDirectory();
			string jsonPath = currentDirectory + "\\save.json";

			if (!System.IO.File.Exists(jsonPath))
			{
				Console.WriteLine("ファイルが無いので、新しいファイル生成して書き込みます。");
				Console.WriteLine("出力先: " + jsonPath);

				Player dummy = MakeDefaultData();
				SavePlayerJson(dummy, jsonPath);
			}
			
			Player loadedPlayer;
			if(!LoadPlayerJson(jsonPath, out loadedPlayer))
			{
				return;
			}

			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");
			string Playername = Logger.ReadInput();

			//create player
			Player player = new Player(Playername, 100f, 10f, 5f, 1, 0, 
				new Weapon("剣", 20f, 20));

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while(world.Loop())
			{
				//Enter入力を待つ
				Logger.ReadInput();
				

				SavePlayerJson(player, jsonPath);
				
			}

			//THE END
			Logger.Log("game over.");
		}
		//セーブ
		private static void SavePlayerJson(Player data,string filPath)
		{
			string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(filPath,jsonText);
		}
		//ロード

		private static bool LoadPlayerJson(string filePath,out Player loadedInstance)
		{
			try
			{
				string jsonText = System.IO.File.ReadAllText(filePath);
				loadedInstance = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(jsonText);
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("ロード失敗:"+e.Message);
				loadedInstance = null;
				return false;
			}
		}
		//最初
		private static Player MakeDefaultData()
		{
			Player NP = new Player("new", 100f, 10f, 5f, 1, 0,
				new Weapon("Sword", 20f, 20));
			return NP;
		}

	}
}
