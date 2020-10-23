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
			int action_num = 0;
			BattleState battleState = BattleState.Continue;
			Logger.Log("何をしますか\n1 = 移動(敵とバトル)\n2 = セーブ");
			action_num = int.Parse(Console.ReadLine());

			switch (action_num) {
				case 1:
			//敵を生成
			Enemy enemy = new Enemy("敵", 30, 10, 2, 0,10);
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
					Logger.Log("セーブしました。");
					System.IO.File.WriteAllText(System.IO.Directory.GetCurrentDirectory()+"\\player.json", Newtonsoft.Json.JsonConvert.SerializeObject(MyPlayer));
					return battleState == BattleState.Continue;
					break;
				default:
					Logger.Log("該当の数値を入力してください");
					return battleState == BattleState.Continue;
					break;
			}


			//勝利ならループ継続
			return battleState == BattleState.Win;
		}


	}
}
