using System;

namespace ConsoleQuest
{
	class Program
	{
		private static readonly string LogDataPath =
		System.IO.Directory.GetCurrentDirectory() + "\\logdata.json";
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			//Logdataを宣言
			LogData loaddata = new LogData();

			try
			{
				//ファイル内を初期化
				string jsonData = System.IO.File.ReadAllText(LogDataPath);
				jsonData = " ";
				System.IO.File.WriteAllText(LogDataPath, jsonData);
			}
			catch { 
			}
			Logger.Log("Start Game!");

			Logger.Log("プレイヤーの名前を入力してください");

			string Playname = Logger.ReadInput();

			//create player
			Player player = new Player(Playname, 100f, 10f, 5f, 1, 0);

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while (world.Loop())
			{

				//jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(loaddata.Ldata);
				//System.IO.File.AppendAllText(LogDataPath, jsonData);
				//Enter入力を待つ
				Logger.ReadInput();
			}

			//THE END
			Logger.Log("game over.");
		}


	}
}