using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class World
	{
		private Player MyPlayer;
		

		public World(Player player)
		{
			MyPlayer = player;
		}


		public bool Loop()
		{
			
			//敵を生成
			/*System.Random random = new Random();//敵のランダム出現
                int j = random.Next(2) + 1;*/
			Enemy enemy = new Enemy("敵", 30, 10, 2, 10);
			Logger.Log(enemy.Name + "が現れた！");


			Battle battle = new Battle(MyPlayer, enemy);

			//敵とバトル

			BattleState battleState = BattleState.Continue;

			do
			{
				battleState = battle.AdvanceTurn();

				Logger.ReadInput();
			}
			while (battleState == BattleState.Continue);


			//勝利ならループ継続
			return battleState == BattleState.Win;
		}


	}
}
