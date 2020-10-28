using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			//string path = @"C:\Users\student\Desktop\123.txt";
			string path = @"C:\Users\yuri6\Desktop\YUN\123.txt";

			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");

			Logger.Log("Please enter desired PLAYER name");

			string Playname = Logger.ReadInput();

			//create player

			Player player = new Player(Playname, 100f, 10f, 5f, 1, 0, 0);
			//create world
			//World world = new World(player);
			
			

			while(true){
				/*
				 Logger.Log("Player Information : ");
				string loadplayer = Newtonsoft.Json.JsonConvert.SerializeObject(player);
				Console.WriteLine(loadplayer);
				*/
				World world = new World(player);
				Logger.Log("select your action ! ");
				Logger.Log(" 1. Battle   2. Shop  3. Rest  4. Save  5. Load");

				int select = Convert.ToInt32(Logger.ReadInput());

					switch (select)
					{
						case 1:
							//worldが終了判定(false)を返すまでループ
							world.Loop();
						
							//Enter入力を待つ
							Logger.ReadInput();
						
						break;

					case 2:
						


						break;

					case 3:
						break;

					case 4:

						string saveplayer = Newtonsoft.Json.JsonConvert.SerializeObject(player);
						System.IO.File.WriteAllText(path, saveplayer);

						Logger.Log(saveplayer);

						break;

					case 5:
						string loadplayer = System.IO.File.ReadAllText(path);
						Player playerloaded = Newtonsoft.Json.JsonConvert.
												 DeserializeObject <Player>(loadplayer);



						Logger.Log(loadplayer);
						float playerloaded1 = float.Parse(loadplayer);
						int playerloaded2 = Int32.Parse(loadplayer);

						player = new Player(loadplayer, playerloaded1, playerloaded1, playerloaded1, playerloaded2, playerloaded2, playerloaded2);


						break;

					}
			}


			Logger.Log("game over.");

			/*
			if (select == 1)
			{
				//worldが終了判定(false)を返すまでループ
				while (world.Loop())
				{
					//Enter入力を待つ
					Logger.ReadInput();
				}
			}

			if (select == 2)
            {

				Logger.Log("test");
            }
			*/
			//THE END
		}
	}
}
