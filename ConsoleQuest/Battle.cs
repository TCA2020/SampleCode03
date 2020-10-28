using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Battle
	{
		private Player BattlePlayer;
		private Enemy BattleEnemy;

		public Battle(Player player, Enemy enemy)
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
			float damage = BattlePlayer.Attack(BattleEnemy);
			Logger.Log(BattlePlayer.Name + " has attacked !! " + BattleEnemy.Name + " has taken " + damage + " damage ");
			
			if(!BattleEnemy.IsAlive)
			{
				Logger.Log(BattleEnemy.Name + " has been defeated . . . ");
				return BattleState.Win;
			}

			damage = BattleEnemy.Attack(BattlePlayer);
			Logger.Log(BattleEnemy.Name + " has attacked !! " + BattlePlayer.Name + " has taken " + damage + " damage ");

			if(!BattlePlayer.IsAlive)
			{
				Logger.Log(BattlePlayer.Name + " has won the battle !");
				return BattleState.Lose;
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
