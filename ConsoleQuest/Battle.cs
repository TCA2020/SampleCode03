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
			Logger.Log( BattlePlayer.Name+"  HP:"+BattlePlayer.HP+"/"+BattlePlayer.MaxHP+"  MP:"+BattlePlayer.MP+"/"+BattlePlayer.MaxMP);
			Logger.Log(BattleEnemy.Name + " HP:" + BattleEnemy.HP + "/" + BattleEnemy.MaxHP);
			Logger.Log("行動入力 1:攻撃　2:強攻撃:消費MP10  3:防御 4:回復薬使用 \n回復薬所持数:" + BattlePlayer.HealNum);
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
							BattlePlayer.LevelUP();
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
					if(BattlePlayer.MP >= 10)
					{
						damage = BattlePlayer.PowerAttack(BattleEnemy);

						Logger.Log("MPを10消費");
						Logger.Log(BattlePlayer.Name + "の強攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ");

						if (!BattleEnemy.IsAlive)
						{
							Logger.Log(BattleEnemy.Name + "を倒した！");
							BattlePlayer.GetCoin(BattleEnemy);
							Logger.Log(BattleEnemy.GainCoin + "Gを手に入れた");

							//経験値計算とレベルアップ
							if (BattlePlayer.EXPCall(BattleEnemy))
							{
								BattlePlayer.LevelUP();
							}


							return BattleState.Win;
						}

						damage = BattleEnemy.Attack(BattlePlayer);

						Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

						if (!BattlePlayer.IsAlive)
						{
							Logger.Log(BattlePlayer.Name + "は倒れた...");
							return BattleState.Lose;
						}
					}
					else
					{
						Logger.Log("MPが足りないようだ");
						return BattleState.Continue;

					}
					break;

				case 3:
　　　　　　　　　　//player防御
					Logger.Log("守りの体制に入った");
					damage = BattleEnemy.Defend(BattlePlayer);
					Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

					if (!BattlePlayer.IsAlive)
					{
						Logger.Log(BattlePlayer.Name + "は倒れた...");
						return BattleState.Lose;
					}
					break;

				case 4:
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
					else
					{
						Logger.Log("回復薬が足りないようだ");
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
