using System;

namespace ConsoleQuest
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.Inject(new ConsoleLogger(), new ConsoleInput());

			Logger.Log("Start Game!");


			//create player
			Player player = new Player("プレイヤー", 100f, 10f, 5f, 1, 0);

			//create world
			World world = new World(player);

			//worldが終了判定(false)を返すまでループ
			while(world.Loop())
			{
				//Enter入力を待つ
				Logger.ReadInput();
			}
			//hahahaha

			Logger.Log("game over.");
		}
	}
}
