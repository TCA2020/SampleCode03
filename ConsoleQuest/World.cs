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
			//敵を生成
			Random r1 = new System.Random();
            switch (r1.Next(0,5)) {
				case 0:
					Enemy enemy = new Enemy("敵", 30, 10, 2, 10);
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
