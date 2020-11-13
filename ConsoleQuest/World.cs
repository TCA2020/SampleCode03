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
			int action = 0;
			int action2 = 0;
			Console.Clear();
			BattleState battleState = BattleState.Continue;
			Cityarea cityarea = Cityarea.Continue;
			Logger.Log("---------\n" + MyPlayer.Name + "\nLv:" + MyPlayer.Level + "\nHP:" + MyPlayer.HP + "/" + MyPlayer.MaxHP + "\nMP:" + MyPlayer.MP + "/" + MyPlayer.MaxMP
				+ "\n攻撃力:" + MyPlayer.ATK + "\n防御力:" + MyPlayer.DEF + /*"\n所持アイテム:" + MyPlayer.Item +*/ "\n所持金" + MyPlayer.Gold + "G");
			Logger.Log("-----行動-----\n1=経験値確認\n2=戦闘\n3=街に行く\n4=セーブ");
			action = Try_Catch();
			switch (action)
			{
				
				case 1:
					Logger.Log("EXP" + MyPlayer.Exp + "/" + MyPlayer.MaxExp);
					return battleState == BattleState.Continue;

				case 2:
                    
                    Enemy enemy = EnemyBattle();
					Logger.Log(enemy.Name + "が現れた！");



					//敵とバトル
					Battle battle = new Battle(MyPlayer, enemy);
					do
					{
						battleState = battle.AdvanceTurn();

						Logger.ReadInput();
					}
					while (battleState == BattleState.Continue);
					break;

				case 3:
					Logger.Log("街に来た。");

					City city = new City(MyPlayer);
					do
					{
						cityarea = city.ActionTurn();

						Logger.ReadInput();
					}
					while (cityarea == Cityarea.Continue);
					break;

				case 4:
					Logger.Log("セーブしました。");
					//セーブ
					System.IO.File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\Player.txt", Newtonsoft.Json.JsonConvert.SerializeObject(MyPlayer));

					Logger.ReadInput();

					Logger.Log("ゲームを終了しますか\nはい=1\nいいえ=2");
					action2 = Try_Catch();
					switch (action2)
					{
						case 1:
							Logger.Log("ゲームを終了します。");
							return battleState == BattleState.Lose;

						default:
							Logger.Log("ゲームを続けます。");
							return battleState == BattleState.Continue;
					}
				default:

					Logger.Log("該当の値を入れてください。");
					return battleState == BattleState.Continue;

			}


			//勝利ならループ継続
			return battleState == BattleState.Win|| battleState == BattleState.Escape || cityarea == Cityarea.finish;
		}

		int Try_Catch()
        {
			int action;
            try
            {
				action = int.Parse(Console.ReadLine());
			}
			catch(Exception e)
            {
				action = 0;
				return action;
            }
            finally
            {
				Console.Clear();
            }
			return action;
        }

		public Enemy EnemyBattle()
		{
			int metal = 0;
			Random er = new Random();//敵のランダム出現
			int enemynum = er.Next(3) + 1;
			Enemy enemy = new Enemy("ゴブリン", 15, 10, 5, 10, 13, 5);
			switch (enemynum)
			{
				case 1:
					Random slimeRm = new Random();//敵のランダム出現
					metal = er.Next(4) + 1;
					if (metal != 4)
					{
						enemy = new Enemy("スライム", 10, 5, 2, 10, 5, 2);
					}
					else
					{
						enemy = new Enemy("メタル", 5, 10, 30, 10, 50, 25);
					}
					break;

				case 2:
					enemy = new Enemy("ゴブリン", 15, 10, 5, 10, 10, 5);
					break;

				case 3:
                    if (MyPlayer.Level >= 5)
                    {
					enemy = new Enemy("オーガ", 30, 20, 15, 10, 20, 20);
                    }
					break;

				case 4:
                    if (MyPlayer.Level >= 10)
                    {
					enemy = new Enemy("トロール", 40, 25, 20, 10, 30, 30);
                    }
					break;

				default:
					enemy = new Enemy("スライム", 10, 5, 2, 10, 5, 2);
					break;
			}

			if (MyPlayer.Level >= 5 )
			{
				if (enemynum >= 1)
				{
					if (enemynum == 4 && MyPlayer.Level >= 15)
					{
						for (int i = 1; MyPlayer.Level >= 5 * i; i++)
						{
							if(i==3)
								EnemyLvUP(enemy);
						}
					}else if (enemynum == 3 && MyPlayer.Level >= 10)
					{
						for (int i = 1; MyPlayer.Level >= 5 * i; i++)
						{
							if(i==2)
								EnemyLvUP(enemy);
						}
					}else if(enemynum != 3)
					{
						for (int i = 1; MyPlayer.Level >= 5 * i; i++)
						{
							if(metal !=4)
								EnemyLvUP(enemy);
						}
					}
				}
			}
			return enemy;
			
		}

		public void EnemyLvUP(Enemy enemy)
        {
						
				enemy.LevelUpEnemy();
		}
	}
}
