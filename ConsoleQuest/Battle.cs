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
					//playerの攻撃
					Console.Clear();
					float damage = BattlePlayer.Attack(BattleEnemy);

					Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ");
			
					if(!BattleEnemy.IsAlive)
					{
						Logger.Log(BattleEnemy.Name + "を倒した！");
						BattlePlayer.GetCoin(BattleEnemy);
						Logger.Log("経験値" + BattleEnemy.GainExp + "を手に入れた");
						Logger.Log(BattleEnemy.GainCoin + "Gを手に入れた");

						//経験値計算とレベルアップ
						BattlePlayer.EXPCall(BattleEnemy);
					


						return BattleState.Win;
			        }
					break;

				case 2:
					//player強攻撃
					Console.Clear();
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
							BattlePlayer.EXPCall(BattleEnemy);


							return BattleState.Win;
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
					Console.Clear();
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
					Console.Clear();
					if(BattlePlayer.HealNum > 0)
					{
						Logger.Log("回復薬を使った");
                        BattlePlayer.Heal(BattlePlayer);

					}
					else
					{
						Logger.Log("回復薬が足りないようだ");
						return BattleState.Continue;
					}
					break;
				default:
					Logger.Log("該当数値を入力してください");
					return BattleState.Continue;
			}

			//enemyの攻撃
			if (action_num != 3)
			{
				float damage = BattleEnemy.Attack(BattlePlayer);

				Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

				if (!BattlePlayer.IsAlive)
				{
					Logger.Log(BattlePlayer.Name + "は倒れた...");
					return BattleState.Lose;
				}
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
