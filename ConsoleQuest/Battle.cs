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
			if (BattleEnemy.HP > 0)
			{
				Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ :: Enemy HP : " + BattleEnemy.HP);
			}
            else
            {
				Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ :: Enemy HP :  0 " );
			}
			

			if (!BattleEnemy.IsAlive)
			{

				Logger.Log(BattleEnemy.Name + "を倒した！");
				Logger.ReadInput();
				Logger.ClearLog();
				
				BattlePlayer.Get_expLVL(BattleEnemy);



				return BattleState.Win;
			}

			damage = BattleEnemy.Attack(BattlePlayer);
            if (BattlePlayer.HP>0)
            {
				Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ :: " + BattlePlayer.Name + " HP : " + BattlePlayer.HP);
			}
            else
            {
				Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ :: " + BattlePlayer.Name + " HP :  0 " );
			}
			
			if (!BattlePlayer.IsAlive)
			{
				Logger.Log(BattlePlayer.Name + "は死んた...");
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
