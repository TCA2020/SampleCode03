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

			Logger.Log("プレイヤーの名前を入力してください");

			string Playname = Logger.ReadInput();

			string currentDerectory=System.IO.Directory.GetCurrentDirectory();
			//currentDirectonryにjsonが置いてある前提
			string jsonPath=currentDerectory+"\\Player.txt";

			if ( !System.IO.File.Exists( jsonPath ) )
			{
				Player dummy=MakeDefaultData();
				SavePlayerJson(dummy,jsonPath);
			}


			//	保存されているjsonデータをロードする
			Player loadedPlayer;
			if(!LoadPlayerJson(jsonPath, out loadedPlayer ) )
			{
				//ロードに失敗した
				return;
			}



			//create player
			Player player = new Player(Playname, 100f, 10f, 5f, 1, 0);

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while(world.Loop())
			{
				//Enter入力を待つ
				Logger.ReadInput();
			}


			Logger.Log("game over.");
		}

		private static void SavePlayerJson(Player date,string filePath )
		{
			string charajson=Newtonsoft.Json.JsonConvert.SerializeObject(date);
			System.IO.File.WriteAllText(filePath,charajson);
		}

		private static bool LoadPlayerJson(string filePath,out Player loadedInstance)
		{
			try
			{
				string Charajson=System.IO.File.ReadAllText(filePath);
				loadedInstance=Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(Charajson);
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("ロード失敗:"+e.Message);
				loadedInstance=null;
				return false;
			}
		}


		//Json出力のため、最初に入れておくためのデータを作る
		private static Player MakeDefaultData( )
		{
			Player player=new Player("プレイヤー", 100f, 10f, 5f, 1, 0);

			return player;
		}
	}
}
