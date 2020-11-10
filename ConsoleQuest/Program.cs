using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			//string path = @"C:\Users\student\Desktop\123.txt";
			string path = System.IO.Directory.GetCurrentDirectory() + "\\123.txt";

			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");

			Logger.Log("Please enter desired PLAYER name");

			string Playname = Logger.ReadInput();

			//create player

			Player player = new Player(Playname, 100f, 100f, 10f, 5f, 1, 0, 0);

			//create world

			while(true){
			World world = new World(player);
			//World world = new World(player);
			
			

				Logger.Log(" ");
				Logger.Log(" ");
				Logger.Log(" ");
				Logger.Log(" ");
				Logger.Log(" ");
				//Logger.Log("Player Information : " + Player(player));
				
				string currentplayer = Newtonsoft.Json.JsonConvert.SerializeObject(player);
				Console.WriteLine(currentplayer);
				
				
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




						player = new Player(playerloaded.Name, playerloaded.MaxHP, playerloaded.HP,playerloaded.AttackPoint,playerloaded.DefencePoint,playerloaded.Level,playerloaded.Exp,playerloaded.Potion);

						Logger.Log(loadplayer);

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
