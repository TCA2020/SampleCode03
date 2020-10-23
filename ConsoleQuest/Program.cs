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

			Console.WriteLine(loadedPlayer.Name,loadedPlayer.MaxHP,loadedPlayer.HP,loadedPlayer.AttackPoint,loadedPlayer.DefencePoint,loadedPlayer.Level,loadedPlayer.Exp);

			Logger.Log("プレイヤーの名前を入力してください");

			string Playname = Logger.ReadInput();

			Logger.Log("---------\n" + MyPlayer.Name + "\nLv:" + MyPlayer.Level + "\nMaxHP/HP:" + MyPlayer.MaxHP + "/" + MyPlayer.HP + "\n攻撃力:" + MyPlayer.AttackPoint + "防御力:" + MyPlayer.DefencePoint + "\n---------");


			//create player
			Player player = new Player(Playname, 100f, 10f, 5f, 1, 0,20);

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
			Player player=new Player("プレイヤー", 100f, 10f, 5f, 1, 0,20);

			return player;
		}
	}
}
