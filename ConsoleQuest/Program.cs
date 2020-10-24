using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			string currentDirectory = System.IO.Directory.GetCurrentDirectory();

			string jsonPath = currentDirectory + "\\playerData.json";

			string Playname;

			int num;

			Logger.Log("Start Game!");

			Logger.Log("新しく始めますか:0\n続きから始めますか:1");

			string start = Logger.ReadInput();

			int.TryParse(start, out num);

			Player player;

			if (num == 0)
			{

				Logger.Log("プレイヤーの名前を入力してください");

				Playname = Logger.ReadInput();

				//create player
				player = new Player(Playname, 100f, 10f, 5f, 1, 0);

				Logger.Log("プレイヤーデータを生成します");
				Logger.Log("出力先:" + jsonPath);

				SaveUserJson(player, jsonPath);
			}
			else if (num == 1)
			{
				Player loadedData;
				if (!LoadUserJson(jsonPath, out loadedData))
				{
					return;
				}
				Console.WriteLine(loadedData.MaxHP.ToString(), loadedData.AttackPoint.ToString(),
					loadedData.Level.ToString());

				player = loadedData;
			}

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while (world.Loop())
			{
				//Enter入力を待つ
				Logger.ReadInput();
			}

			//THE END
			Logger.Log("game over.");
		}

		private static void SaveUserJson(Player data, string path)
		{
			string jsontext = Newtonsoft.Json.JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(path, jsontext);
		}

		private static bool LoadUserJson(string path, out Player loadedData)
		{
			try
			{
				string jsontext = System.IO.File.ReadAllText(path);
				loadedData = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(jsontext);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine("ロード失敗;" + e.Message);
				loadedData = null;
				return false;
			}
		}
	}
}
