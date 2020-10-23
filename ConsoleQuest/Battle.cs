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
			int action_num = 0;
			Logger.Log("行動入力 1:攻撃　2:防御 3:回復薬使用 \n回復薬所持数:" + BattlePlayer.HealNum);
			action_num = int.Parse(Console.ReadLine());
			switch (action_num) {
				case 1:
					//プレイヤーと敵が殴り合う
					float damage = BattlePlayer.Attack(BattleEnemy);
					Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ");
			
					if(!BattleEnemy.IsAlive)
					{
						Logger.Log(BattleEnemy.Name + "を倒した！");
						BattlePlayer.GetCoin(BattleEnemy);
						Logger.Log(BattleEnemy.GainCoin + "Gを手に入れた");

						//経験値計算とレベルアップ
						if (BattlePlayer.EXPCall(BattleEnemy))
						{
							BattlePlayer.LevelUP(BattlePlayer);
						}


						return BattleState.Win;
			}

			damage = BattleEnemy.Attack(BattlePlayer);
			Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

			if(!BattlePlayer.IsAlive)
			{
				Logger.Log(BattlePlayer.Name + "は倒れた...");
				return BattleState.Lose;
			}
					break;

				case 2:
　　　　　　　　　　//player防御
					Logger.Log("守りの体制に入った");
					damage = BattleEnemy.Defend_Attack(BattlePlayer);
					Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

					if (!BattlePlayer.IsAlive)
					{
						Logger.Log(BattlePlayer.Name + "は倒れた...");
						return BattleState.Lose;
					}
					break;

				case 3:
					//回復薬使用
					if(BattlePlayer.HealNum > 0)
					{
						float healPoint = 0;
						Logger.Log("回復薬を使った");
						healPoint = BattlePlayer.Heal(BattlePlayer);
						Logger.Log(healPoint + "回復した");

						damage = BattleEnemy.Attack(BattlePlayer);
						Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

						if (!BattlePlayer.IsAlive)
						{
							Logger.Log(BattlePlayer.Name + "は倒れた...");
							return BattleState.Lose;
						}
					}
					break;
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
