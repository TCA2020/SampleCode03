using System;
using System.Collections.Generic;
using System.Reflection.Emit;
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
			int action_num = 0;
			BattleState battleState = BattleState.Continue;
			Logger.Log(MyPlayer.Name +"\nLv"+MyPlayer.Level+ " MaxHP/HP:"+MyPlayer.MaxHP +"/"+ MyPlayer.HP+" お金:"+MyPlayer.Coin+"G");
			Logger.Log("何をしますか\n1 = 移動(敵とバトル)\n2 = 回復薬使用  回復薬所持数:" + MyPlayer.HealNum + "\n3 = 回復薬購入　50G\n4 = セーブ");
			action_num = int.Parse(Console.ReadLine());

			switch (action_num)
			{
				case 1:
					//敵を生成
					Enemy enemy = new Enemy("敵", 30, 10, 2, 0, 10, 10);
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

				case 2:
					//回復薬使用
					if(MyPlayer.HealNum > 0)
					{
						MyPlayer.Heal(MyPlayer);
						Logger.Log("回復薬で回復しました");
					}
					else
					{
						Logger.Log("回復薬がありませんでした");

					}
					return battleState == BattleState.Continue;

				case 3:
					//回復薬購入
					if (MyPlayer.Coin >= 50)
					{
						MyPlayer.GetHeal();
						Logger.Log("回復薬を購入した");
						return battleState == BattleState.Continue;
					}
					else
					{
						Logger.Log("Gが足りません");
						return battleState == BattleState.Continue;
					}

				case 4:
					//save
					Logger.Log("セーブしました。");
					System.IO.File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\player.json", Newtonsoft.Json.JsonConvert.SerializeObject(MyPlayer));
					return battleState == BattleState.Continue;

				default:
					Logger.Log("該当の数値を入力してください");
					return battleState == BattleState.Continue;
					
			}


			//勝利ならループ継続
			return battleState == BattleState.Win;
		}


	}
}
