﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class World
	{
		private Player MyPlayer;

		private Enemy[] loadEnemy;

		Random enemypop = new Random();

		public World(Player player,Enemy[] load)
		{
			MyPlayer = player;

			loadEnemy = load;
		}

		public bool Loop()
		{
			//敵を生成
			Enemy enemy = loadEnemy[enemypop.Next(0, 3)];
			copyEnemy copyEnemy = Copy(enemy);

			Logger.Log(copyEnemy.Enemy.Name + "が現れた！");

			//敵とバトル
			Battle battle = new Battle(MyPlayer, copyEnemy);

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

		public copyEnemy Copy(Enemy loadenemy)
		{
			copyEnemy enemy = new copyEnemy();
			enemy.Enemy = loadenemy;
			enemy.Enemy.HP = loadenemy.MaxHP;

			return enemy;
		}


	}
}
