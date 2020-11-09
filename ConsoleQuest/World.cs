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

			Logger.Log("現在の" + MyPlayer.Name + "HPは" + MyPlayer.HP);


			//敵を生成
			Enemy enemy = new Enemy("敵", 30, 10, 2, 10);
			Logger.Log(enemy.Name + "が現れた！");

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
