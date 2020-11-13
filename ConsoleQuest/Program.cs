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
			Logger.Log("プレイヤーの名前を入力してください");


			string Playname = Logger.ReadInput();

			if (player == null)
            {

				player = new Player(Playname, 100f, 10f, 5f, 1, 5);
			}
			else
			{
				//ロードに成功した
				Logger.Log("続きから始めます");
			}
		

			//create player
	

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while(world.Loop())
			{
				SavePlayer(player);
				//Enter入力を待つ
				Logger.ReadInput();
			}


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
			saveData.Player.MaxMP = player.MaxMP;
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


