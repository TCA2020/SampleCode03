using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Battle
	{
		private Player BattlePlayer;
		private copyEnemy BattleEnemy;

		public Battle(Player player, copyEnemy enemy)
		{
			BattlePlayer = player;
			BattleEnemy = enemy;
		}

		/// <summary>
		/// ターンを進める
		/// </summary>
		/// <returns>処理終了後のバトル状況</returns>
		public BattleState AdvanceTurn()
		{
			//プレイヤーと敵が殴り合う
			float damage = BattlePlayer.Attack(BattleEnemy.Enemy);
			Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Enemy.Name + "に" + damage + "のダメージ");
			
			if(!BattleEnemy.Enemy.IsAlive)
			{
				Logger.Log(BattleEnemy.Enemy.Name + "を倒した！");
				return BattleState.Win;
			}
			else
			{
				Logger.Log("敵の残りHP:" + BattleEnemy.Enemy.HP);
			}

			damage = BattleEnemy.Enemy.Attack(BattlePlayer);
			Logger.Log(BattleEnemy.Enemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

			if(!BattlePlayer.IsAlive)
			{
				Logger.Log(BattlePlayer.Name + "は倒れた...");
				return BattleState.Lose;
			}
			else
			{
				Logger.Log(BattlePlayer.Name + "の残りHP:" + BattlePlayer.HP);
			}

			return BattleState.Continue;
		}
	}

	public enum BattleState
	{
		Win,
		Lose,
		Continue,
	}
}
