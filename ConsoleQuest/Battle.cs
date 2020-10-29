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
			int action = 0;
			float damage = 0;
			Logger.Log("---------\n"+BattlePlayer.Name+"\nHP:" + BattlePlayer.HP+"\nMP:"+BattlePlayer.MP+"\nLv:"+BattlePlayer.Level);
			Logger.Log("---------\n" + BattleEnemy.Name + "\nHP:" + BattleEnemy.HP + "/" + BattleEnemy.MaxHP+"\n");
			Logger.Log("---行動入力---\n1=通常攻撃\n2=魔法攻撃\n3=防御\n4=逃げる");
			action = int.Parse(Console.ReadLine());

			switch (action)
            {
				case 1:

					damage = BattlePlayer.NormalAttack(BattleEnemy);
					Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ");

					if (!BattleEnemy.IsAlive)
					{
						Logger.Log(BattleEnemy.Name + "を倒した！");
						//経験値取得&レベルアップ
						BattlePlayer.EXPCalc(BattleEnemy);
						BattlePlayer.GoldCalc(BattleEnemy);

						return BattleState.Win;
					}

					break;

				case 2:
					if (BattlePlayer.MP >= 5)
					{
						damage = BattlePlayer.MagicAttack(BattleEnemy);
						Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ");

						if (!BattleEnemy.IsAlive)
						{
							Logger.Log(BattleEnemy.Name + "を倒した！");
							//経験値取得&レベルアップ
							BattlePlayer.EXPCalc(BattleEnemy);
							BattlePlayer.GoldCalc(BattleEnemy);

							return BattleState.Win;
						}
                    }
                    else
                    {
						
						Logger.Log("MPが足りません。");
						return BattleState.Continue;
                    }

					break;

				case 3:
					damage = BattleEnemy.Defense(BattlePlayer);
					Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

					if (!BattlePlayer.IsAlive)
					{
						Logger.Log(BattlePlayer.Name + "は倒れた...");
						return BattleState.Lose;
					}
					return BattleState.Continue;


				case 4:

					System.Random random = new Random();
					int escape = random.Next(2) + 1;

					if (escape == 1)
                    {
						Logger.Log(BattlePlayer.Name + "は"+BattleEnemy.Name+ "から逃げた。");
						return BattleState.Escape;
                    }
                    else
                    {
						Logger.Log("逃げられなかった。");
                    }

					break;


			}
			

			damage = BattleEnemy.NormalAttack(BattlePlayer);
			Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");

			if(!BattlePlayer.IsAlive)
			{
				Logger.Log(BattlePlayer.Name + "は倒れた...");
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
		Escape,
	}
}
