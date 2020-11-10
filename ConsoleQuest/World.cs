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
			BattleState battleState = BattleState.Continue;
			Cityarea cityarea = Cityarea.Continue;
			Logger.Log("---------\n" + MyPlayer.Name + "\nLv:" + MyPlayer.Level + "\nHP:" + MyPlayer.HP + "/" + MyPlayer.MaxHP + "\nMP:" + MyPlayer.MP + "/" + MyPlayer.MaxMP
				+ "\n攻撃力:" + MyPlayer.ATK + "\n防御力:" + MyPlayer.DEF + "\n所持アイテム:" + MyPlayer.Item + "\n所持金" + MyPlayer.Gold + "G");
			try
			{
			Logger.Log("-----行動-----\n1=経験値確認\n2=戦闘\n3=街に行く\n4=セーブ");
			action = int.Parse(Console.ReadLine());
            switch (action)
            {
				case 1:
					Logger.Log("EXP" + MyPlayer.Exp +"/"+ MyPlayer.MaxExp); 
					return battleState == BattleState.Continue;

				case 2:

					Enemy enemy = new Enemy("敵", 30, 10, 2, 10, 15, 5);
					Logger.Log(enemy.Name + "が現れた！");


					Battle battle = new Battle(MyPlayer, enemy);

					//敵とバトル

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
					action2 = int.Parse(Console.ReadLine());
					switch (action2)
					{
						case 1:
							Logger.Log("ゲームを終了します。");
							return battleState == BattleState.Lose;

						case 2:
							Logger.Log("ゲームを続けます。");
							return battleState == BattleState.Continue;

					}
					break;
					
			}
			}
			catch(Exception e)
			{
				Logger.Log("該当の値を入れてください。");
				return battleState == BattleState.Continue;
			}


			//勝利ならループ継続
			return battleState == BattleState.Win|| battleState == BattleState.Escape || cityarea == Cityarea.finish;
		}


	}
}
