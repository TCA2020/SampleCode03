using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			string currentDirectory = System.IO.Directory.GetCurrentDirectory();

			string jsonPath = currentDirectory + "\\playerData.text";

			string enemyPath = currentDirectory + "\\enemyData.text";

			Logger.Log("Start Game!");

			Player player;

			//JsonEnemy(enemyPath);

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
						Console.WriteLine(loadedData.MaxHP.ToString(), loadedData.AttackPoint.ToString(),
							loadedData.Level.ToString());

						player = loadedData;

						break;
					}
				}
				Logger.Log("0か1以外が入力されました");
				Logger.Log("もう一度入力してください");
				
			}

			//create world
			World world = new World(player,EnemyLoad(enemyPath));

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

		private static Enemy[] EnemyLoad(string path)
		{

			Enemy[] loadEnemy = new Enemy[3];

			string jsontext = System.IO.File.ReadAllText(path);

			loadEnemy = Newtonsoft.Json.JsonConvert
				.DeserializeObject < Enemy[] > (jsontext);

			return loadEnemy;
		}

		/*
		public static void CreateEnemyJson(string jsontext,string path)
		{
			System.IO.File.WriteAllText(path, jsontext);
		}

		static void JsonEnemy(string path)
		{
			Enemy[] enemy = new Enemy[3];

			enemy[0] = new Enemy("敵1", 30, 10, 2, 10);

			enemy[1] = new Enemy("敵2", 50, 5, 3, 20);

			enemy[2] = new Enemy("敵3", 10, 20, 1, 20);

			string enemytext = Newtonsoft.Json.JsonConvert.SerializeObject(enemy);

			CreateEnemyJson(enemytext, path);
		}
		*/
	}
}
