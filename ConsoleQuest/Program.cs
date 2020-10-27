using System;
using Newtonsoft.Json;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			string currentDerectory=System.IO.Directory.GetCurrentDirectory();
			//currentDirectonryにjsonが置いてある前提
			string jsonPath=currentDerectory+"\\Player.txt";
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

		

			if ( !System.IO.File.Exists( jsonPath ) )
			{
				Console.WriteLine("Jsonファイルが無いので、ダミーデータを元にJsonを生成して書き込みます...");
				Player dummy=MakeDefaultData();
				SavePlayerJson(dummy,jsonPath);
			}

			Logger.Log("Start Game!");

			//	保存されているjsonデータをロードする
			Player loadedPlayer;
			if(!LoadPlayerJson(jsonPath, out loadedPlayer ) )
			{
				//ロードに失敗した
				return;
			}


			if (loadedPlayer.Playing == 0)
			{
				//create world
				Logger.Log("プレイヤーの名前を入力してください");
				string playname = Logger.ReadInput();

				//create player
				Player player = new Player(playname, 100f, 10f, 5f,10f, 1, 1, 0, 20);
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
				Logger.Log("前回の続きから始めます。");
				Player player = loadedPlayer;
				World world = new World(player);

				while (world.Loop())
				{
					Logger.ReadInput();
				}
			}

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


		//Json出力のため、最初に入れておくためのデータを作る
		private static Player MakeDefaultData( )
		{
			Player player=new Player("プレイヤー", 100f, 10f, 5f,10,0, 1, 0,20);

			return player;
		}
	}
}
