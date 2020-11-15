using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("これから冒険を始めます。");

			Player player = LoadPlayerData();
			if (player != null)
			{
				Logger.Log("つづきから");
			}
			else
			{
				//ロードに失敗したorセーブデータがなかった
				Logger.Log("あたらしくはじめます。");
				Logger.Log("冒険者の名前を入力してください。");
				string Playname = Logger.ReadInput();

				//create player
				player = new Player(Playname, 100f, 10f, 5f, 1, 0);

			}



			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while (world.Loop())
			{
				//現在のプレイヤーデータを保存
				SavePlayerData(player);
				//Enter入力を待つ
				Logger.ReadInput();
			}


			Logger.Log("game over.");
		}

		private static readonly string SavedataPath = System.IO.Directory.GetCurrentDirectory() + "\\save.json";
		private static void SavePlayerData(Player player)
		{
			SaveData data = new SaveData();
			data.Player = new PlayerSaveData();
			data.Player.HP = player.HP;
			data.Player.MaxHP = player.MaxHP;
			data.Player.Name = player.Name;
			data.Player.Title = player.Title;
			data.Player.AttackPoint = player.AttackPoint;
			data.Player.DefencePoint = player.DefencePoint;
			data.Player.Level = player.Level;
			data.Player.Exp = player.Exp;

			string dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(data);

			System.IO.File.WriteAllText(SavedataPath, dataJson);
		}
		private static Player LoadPlayerData()
		{
			try
			{
				string dataJson = System.IO.File.ReadAllText(SavedataPath);
				SaveData saveData = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(dataJson);

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
