using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			

			string currentDirectory = System.IO.Directory.GetCurrentDirectory();
			string jsonPath = currentDirectory + "\\play.json";
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

            if(!System.IO.File.Exists(jsonPath))
			{
				Console.WriteLine("Jsonファイルが無いので、ダミーデータを元にJsonを生成して書き込みます...");
				Player dummy = MakeDefaultData();
				SavePlayerJson(dummy, jsonPath);
			}

			Player loadedPlayer;
			if (!LoadPlayerJson(jsonPath, out loadedPlayer))
			{
				//ロードに失敗した
				return;
			}


			Player player = new Player(Playname, 100, 10, 10,
				new List<string>() { "薬草", "毒消し草" },
				new Weapon("銅の剣", 10F, 300),
				10, 10
				);

			//string Playerjson =
			//System.IO.File.ReadAllText(@"C:\character_player.txt");


			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");

			player = LoadPlayerData();
			if(player!=null)
			{
				Logger.Log("続きから始めます");
			}
			//else
			//{
			//	Logger.Log("新しく始めます");
			//	Logger.Log("プレイヤーの名前を入力してください入力してください");
			//	string Playname = Logger.ReadInput();

			//	player = new Player= Logger.ReadInput();

			//	player = new Player(Playname, 100f, 10f, 5f 1, 1);
			//}


			//create player
<<<<<<< Updated upstream
			Player player = new Player("プレイヤー", 100f, 10f, 5f, 1, 0);
=======
>>>>>>> Stashed changes

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while(world.Loop())
			{
				//Enter入力を待つ
				Logger.ReadInput();
			}

			//THE END

<<<<<<< Updated upstream

=======
			
>>>>>>> Stashed changes
			Logger.Log("game over.");

		}

		private static readonly string SavedataPath = System.IO.Directory.GetCurrentDirectory() + "\\save.json";
		

		private static void  SavePlayerDeta(Player player)
		{
			savedeta date = new savedeta();
			date.Player = new PlayerSaveDeta();
			date.Player.HP = player.HP;
			date.Player.MaxHP = player.MaxHP;
			date.Player.Name = player.Name;
			date.Player.AttackPoint = player.AttackPoint;
			date.Player.DefencePoint = player.DefencePoint;
			date.Player.Level = player.Level;
			date.Player.Exp = player.Exp;

			string dateJson = Newtonsoft.Json.JsonConvert.SerializeObject(date);
			System.IO.File.WriteAllText(SavedataPath, dateJson);
		}

		private static Player LoadPlayerData()
		{
			try
			{
				string dataJson = System.IO.File.ReadAllText(SavedataPath);
				savedeta saveData = Newtonsoft.Json.JsonConvert.DeserializeObject<savedeta>(dataJson);

				Player player = new Player(saveData.Player);
				return player;
			}
			catch
			{
				return null;
			}
		}



			//Player deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(jsonPath);

		private static void SavePlayerJson(Player data, string filePath)
		{
			string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(filePath, jsonText);
		}



		private static bool LoadPlayerJson(string filePath, out Player loadedInstance)
		{
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
			Player player = new Player("ミク", 100, 10, 10,
				new List<string>() { "薬草", "毒消し草" },
				new Weapon("銅の剣", 10F, 300),10, 10);
			return player;
		}
	}
}
