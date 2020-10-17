using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{

			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");

			Logger.Log("Please enter desired PLAYER name");

			string Playname = Logger.ReadInput();

			//create player
			Player player = new Player(Playname, 100f, 10f, 5f, 1, 0, 0);

			//create world
			World world = new World(player);

			Logger.Log("select your action ! ");
			Logger.Log(" 1. Battle   2. Shop  3. Rest  4. Save  5. Load");

			int select = Convert.ToInt32(Logger.ReadInput());

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
				
            }

			//THE END
			Logger.Log("game over.");
		}
	}
}
