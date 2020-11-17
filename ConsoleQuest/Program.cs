using System;
using Newtonsoft.Json;


namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			

			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");

			Player player=LoadPlayerData();
			if(player !=null)
			{
				Logger.Log("続きから始めす。");
			}
			else
			{
				Logger.Log("新しく始めます。");
			Logger.Log("プレイヤーの名前を入力してください");
			string Playname = Logger.ReadInput();

			player  = new Player(Playname, 100f, 10f, 5f, 1, 0);

			string json = Newtonsoft.Json.JsonConvert.SerializeObject(player);

			/*System.IO.File.WriteAllText(@"D:\player.txt",json);*/

			string currentDirectory = System.IO.Directory.GetCurrentDirectory();
			string jsonPath = currentDirectory + "//player.Txt";
			if (!System.IO.File.Exists(jsonPath))
			{
				Console.WriteLine("Jsonのファイルがないので、ダミーデータを元にJsonを生成して書き込みます…。");
				Console.WriteLine("出力先：" + jsonPath);
				Player dummy = MakeDefaultData();
				SavePlayerJson(dummy, jsonPath);
			Player loadedCar;
			if (!LoadCarJson(jsonPath, out loadedCar))
			{
				return;
			}





			}


			//create player


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

		private static readonly string SavedatePath = System.IO.Directory.GetCurrentDirectory() + "\\save.json";
		
		private static void SavePlayerDeta(Player player)
		{
			SaveDeta deta = new SaveDeta();
			deta.Player = new PlayerSaveDeta();
			deta.Player.HP = player.HP;
			deta.Player.MaxHP=player.MaxHP;
			deta.Player.Name = player.Name;
			deta.Player.AttackPoint = player.AttackPoint;
			deta.Player.DefencePoint = player.DefencePoint;
			deta.Player.Level = player.Level;
			deta.Player.Exp = player.Exp;

			String dateJson = Newtonsoft.Json.JsonConvert.SerializeObject(deta);
			System.IO.File.WriteAllText(SavedatePath, dateJson);

		}
		private static Player LoadPlayerData(/*string filePath,out Player loadedInstance*/)
		{
			try
			{
				string dateJson=System.IO.File.ReadAllText(SavedatePath);
				SaveDeta saveDate = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveDeta>(dateJson);
				Player player = new Player(saveDate.Player);
				return player;
			}
			catch
			{
				return null;
			}
		}


		private static void SavePlayerJson(Player
			data, string filePath)
		{
			string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(filePath, jsonText);
		}
		private static bool LoadCarJson(string filePath, out Player loadedInstance)
		{
			
			
			try
			{
				string jsonText = System.IO.File.ReadAllText(filePath);
				loadedInstance = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(jsonText);
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("ロード失敗:" + e.Message);
				loadedInstance = null;
				return false;
			}
		}

			
			
		
				
			private static Player MakeDefaultData()
				{
				Player player=new Player("プレイヤー", 100f, 10f, 5f, 1, 0);

			
				return player;
				}
	}
	}
