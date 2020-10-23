using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{

			string currentDirectory = System.IO.Directory.GetCurrentDirectory();
			//currentDirectoryにjsonが置いてある前提
			string jsonPath = currentDirectory + "\\player.json";
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			if (!System.IO.File.Exists(jsonPath))
			{
				Console.WriteLine("Jsonファイルが無いので、ダミーデータを元にJsonを生成して書き込みます...");
				Player dummy = MakeDefaultData();
				SavePlayerJson(dummy, jsonPath);
			}

			Logger.Log("Start Game!");

			Player loadedPlayer;
			if (!LoadPlayerJson(jsonPath, out loadedPlayer))
			{
				//ロードに失敗した
				return;
			}
			Console.WriteLine(loadedPlayer.Preing);

			if (loadedPlayer.Preing == 0)
			{
				//create world
				Logger.Log("プレイヤーの名前を入力してください");
				string Playname = Logger.ReadInput();

				//create player
				Player player = new Player(Playname, 100f, 10f, 5f, 1, 0, 1);
				World world = new World(player);

				//worldが終了判定(false)を返すまでループ
				while (world.Loop())
				{
					//Enter入力を待つ
					Logger.ReadInput();
				}
			}
			else
			{
				Player player = loadedPlayer;
				World world = new World(player);

				while (world.Loop())
				{
					Logger.ReadInput();
				}
			}

			//THE END
			Logger.Log("game over.");
		}

		private static void SavePlayerJson(Player data, string filePath)
		{
			string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(filePath, jsonText);
		}

		private static bool LoadPlayerJson(string filePath, out Player loadedInstance)
		{
			//ファイルが存在しない、Jsonフォーマットが正しくないなどの理由で
			//ロードに失敗する可能性があるのでtry-catchを使う
			try
			{
				string jsonText = System.IO.File.ReadAllText(filePath);
				loadedInstance = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(jsonText);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine("ロード失敗:" + e.Message);
				loadedInstance = null;
				return false;
			}
		}

		private static Player MakeDefaultData()
		{
			Player player = new Player("null", 100f, 10f, 5f, 0, 1, 0);


			return player;
		}
	}
}
