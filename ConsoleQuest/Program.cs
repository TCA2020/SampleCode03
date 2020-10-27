using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");



			string currentDir = System.IO.Directory.GetCurrentDirectory();
			string jsonfile = currentDir + "\\data.json";

			Player player = null ;

			if (!System.IO.File.Exists(jsonfile))
			{
				Logger.Log("プレイヤーの名前を入力してください");
				
				string Playname = Logger.ReadInput();

				//create player
				player = new Player(Playname, 100f, 10f, 5f, 1, 0);
				json.savejson(player, jsonfile);
			}
			else if (json.loaddata(jsonfile, out player))
			{



				Console.WriteLine("Jsonからロードをしました。");
				Console.WriteLine("hp:" + player.HP);
				Console.ReadLine();

			}
			
			if (!player.IsAlive) {
				Logger.Log(player.Name+"が死んだので新しいキャラクターを作ります。");
				Logger.Log("プレイヤーの名前を入力してください");
				string Playname = Logger.ReadInput();

				//create player
				player = new Player(Playname, 100f, 10f, 5f, 1, 0);
				json.savejson(player, jsonfile);


			}




			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while (world.Loop())
			{
				json.savejson(player, jsonfile);
				//Enter入力を待つ
			//	Logger.ReadInput();
			}

			//THE END
			Logger.Log("game over.");
			json.savejson(player, jsonfile);
		}
	
	
	


	}
}
