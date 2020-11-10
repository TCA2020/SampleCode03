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

			Logger.Log("Start Game!");

			Player player;

			while (true)
			{
				Logger.Log("新しく始めますか:0\n続きから始めますか:1");

				var start = Logger.ReadInput();
				if (int.TryParse(start, out var num))
				{
					if (num == 0)
					{

						Logger.Log("プレイヤーの名前を入力してください");

						var Playname = Logger.ReadInput();

						//create player
						player = new Player(Playname, 100f, 10f, 5f, 1, 0);

						Logger.Log("プレイヤーデータを生成します");
						Logger.Log("出力先:" + jsonPath);

						SaveUserJson(player, jsonPath);

						break;
					}
					else if (num == 1)
					{
						Player loadedData;
						if (!LoadUserJson(jsonPath, out loadedData))
						{
							return;
						}
						if (loadedData.IsAlive) {
							loadedData.deathheal();
						}
						Console.WriteLine(loadedData.MaxHP.ToString(), loadedData.AttackPoint.ToString(),
							 loadedData.Level.ToString(),loadedData.Exp.ToString());

						player = loadedData;

						break;
					}
				}
				Logger.Log("0か1以外が入力されました");
				Logger.Log("もう一度入力してください");

			}

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while (world.Loop())
			{
				//THE END
				Logger.Log("game over.");
			}
			while (true)
			{
				Logger.Log("今回のプレイデータを保存しますか？:0\n保存せず破棄しますか？:1");

				var start = Logger.ReadInput();
				if (int.TryParse(start, out var num))
				{
					if (num == 0)
					{ 
						SavePlayer(player,jsonPath);
						Console.WriteLine("プレイデータを保存しました。");
						break;
					} else if (num == 1)
					{
						Console.WriteLine("今回のプレイデータを破棄しました。");
						break;
					}
				}
				Logger.Log("0か1以外が入力されました");
				Logger.Log("もう一度入力してください");

			}
			//Enter入力を待つ
			Logger.ReadInput();
		}

		static void SaveUserJson(Player data, string path)
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

		private static void SavePlayer(Player player,string JsonPath)
		{
			SaveDate saveDate = new SaveDate();
			saveDate.Player = new PlayerSaveDate();

			saveDate.Player.Name = player.Name;
			saveDate.Player.maxHP = player.MaxHP;
			saveDate.Player.AttackPoint = player.AttackPoint;
			saveDate.Player.Difencepoint = player.DefencePoint;
			saveDate.Player.level = player.Level;
			saveDate.Player.Exp = player.Exp;

			string jsonDate = Newtonsoft.Json.JsonConvert.SerializeObject(saveDate);
			System.IO.File.WriteAllText(JsonPath, jsonDate);

		}

	}
}