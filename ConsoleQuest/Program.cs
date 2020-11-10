using System;

namespace ConsoleQuest
{
	class Program
	{
		private static readonly string currentDir = System.IO.Directory.GetCurrentDirectory();
		private static readonly string jsonfile = currentDir + "\\data.json";
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");





			Player player = json.LoadPlayer(jsonfile);

			if (player == null)
			{
				Logger.Log("プレイヤーの名前を入力してください");
				
				string Playname = Logger.ReadInput();

				//create player
				player = new Player(Playname, 100f, 10f, 5f, 1, 0);
				json.savejson(player, jsonfile);
			}
			else if (player != null)
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
