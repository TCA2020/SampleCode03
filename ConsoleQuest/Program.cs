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
				Logger.Log("プレイヤーの名前を入力してください");
				string Playname = Logger.ReadInput();
				player = new Player(Playname, 100f, 10f, 5f, 1, 0,20);
			}
			else 
			{
				Logger.Log("続きから");
			}

			//create world
			World world = new World(player);

			while (world.Loop()) 
			{
				SavePlayer(player);
				Logger.ReadInput();
			}

			//THE END
			Logger.Log("game over.");
			
		}
		private static readonly string SaveDataPath
		 = System.IO.Directory.GetCurrentDirectory() + "\\savedata.json";

		private static void SavePlayer(Player player) 
		{
			Savedata saveData = new Savedata();
			saveData.Player = new PlayerSaveData();

			saveData.Player.HP = player.HP;
			saveData.Player.MaxHP = player.MaxHP;
			saveData.Player.Name = player.Name;
			saveData.Player.AttackPoint = player.AttackPoint;
			saveData.Player.DefencePoint = player.DefencePoint;
			saveData.Player.Level = (int)player.Level;
			saveData.Player.EXp = (int)player.exp;

			string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(saveData);
			System.IO.File.WriteAllText(SaveDataPath, jsonData);

		}

		private static Player LoadPlayer()
		{
				try
				{
					string jsonData = System.IO.File.ReadAllText(SaveDataPath);
					Savedata saveData =
						Newtonsoft.Json.JsonConvert.DeserializeObject<Savedata>(jsonData);

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
