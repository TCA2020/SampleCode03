using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest {
	public class Battle {
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

			//追加
			string playerData = JsonConvert.SerializeObject(BattlePlayer);
			//追加
			string enemyData = JsonConvert.SerializeObject(BattleEnemy);

			float damage = BattlePlayer.Attack(BattleEnemy);

			Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ");
			
			//追加
			Console.WriteLine("敵のHP : " + BattleEnemy.HP);


			if (!BattleEnemy.IsAlive)
			{
				Logger.Log(BattleEnemy.Name + "を倒した！");
				

				//追加
				Console.WriteLine(playerData);
				return BattleState.Win;
			}

			damage = BattleEnemy.Attack(BattlePlayer);
			Logger.Log(BattleEnemy.Name + "の攻撃:" + BattlePlayer.Name + "に" + damage + "のダメージ");			

			//追加
			Console.WriteLine("君のHP : " + BattlePlayer.HP);



			if (!BattlePlayer.IsAlive)
			{
				Logger.Log(BattlePlayer.Name + "は倒れた...");
				return BattleState.Lose;
			}

			return BattleState.Continue;
		}
	}

	public enum BattleState {
		Win,
		Lose,
		Continue,
	}
}
