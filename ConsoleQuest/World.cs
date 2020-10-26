using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
			Enemy enemy = new Enemy("敵", 30, 10, 2, 10);
			//敵を生成
			Random r1 = new System.Random();
            switch (r1.Next(0,5)) {
				case 0:
					enemy = new Enemy("敵A", 30, 10, 2, 10);
					Logger.Log(enemy.Name + "が現れた！");
					break;
				case 1:
					enemy = new Enemy("敵B", 50, 8, 4, 30);
					Logger.Log(enemy.Name + "が現れた！");
					break;
				case 2:
					enemy = new Enemy("敵C", 15, 15, 5, 25);
					Logger.Log(enemy.Name + "が現れた！");
					break;
				case 4:
					enemy = new Enemy("敵D", 10, 8, 8, 40);
					Logger.Log(enemy.Name + "が現れた！");
					break;
				case 5:
					enemy = new Enemy("敵E", 40, 20, 3, 15);
					Logger.Log(enemy.Name + "が現れた！");
					break;
				case 6:
					enemy = new Enemy("敵F", 100, 1, 1, 15);
					Logger.Log(enemy.Name + "が現れた！");
					break;

			}

			//敵とバトル
			Battle battle = new Battle(MyPlayer, enemy);

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
