using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");

			Player player = LoadPlayer();
			if (player == null)
			{
				//初回プレイ
				Logger.Log("プレイヤーの名前を入力してください");
				string Playname = Logger.ReadInput();

				//create player
				player = new Player(Playname, 100f, 10f, 5f, 1, 0);
			}
			else
			{
				//ロードに成功した
				Logger.Log("続きから始めます");
			}


			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while (world.Loop())
			{
				//自動でセーブする
				SavePlayer(player);

				//Enter入力を待つ
				Logger.ReadInput();
			}

			//THE END
			Logger.Log("game over.");
		}

		private static readonly string SaveDataPath =
			System.IO.Directory.GetCurrentDirectory() + "\\savedata.json";

		private static void SavePlayer(Player player)
		{
			SaveData saveData = new SaveData();
			saveData.Player = new PlayerSaveData();

			saveData.Player.HP = player.HP;
			saveData.Player.MaxHP = player.MaxHP;
			saveData.Player.Name = player.Name;
			saveData.Player.AttackPoint = player.AttackPoint;
			saveData.Player.DefencePoint = player.DefencePoint;
			saveData.Player.Level = player.Level;
			saveData.Player.Exp = player.Exp;

			string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(saveData);
			System.IO.File.WriteAllText(SaveDataPath, jsonData);
		}

		private static Player LoadPlayer()
		{
			try
			{
				string jsonData = System.IO.File.ReadAllText(SaveDataPath);
				SaveData saveData = Newtonsoft.Json.
					JsonConvert.DeserializeObject<SaveData>(jsonData);
				Player player = new Player(saveData.Player);
				return player;
			}
			catch
			{
				return null;
			}
		}
	}
}