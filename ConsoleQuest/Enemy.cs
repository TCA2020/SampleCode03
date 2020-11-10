using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Enemy : Character
	{
		public int GainExp
		{ get; set; }
		public int GainGold
		{ get; set; }

		public Enemy(string name, float maxHP, float atk, float def, float maxMP,
			int gainExp,int gainGold)
			: base(name, maxHP, atk, def, maxMP)
		{
			GainExp = gainExp;
			GainGold = gainGold;
		}

		public  void EnemyBattle()
        {
			System.Random random = new Random();//敵のランダム出現
			int j = random.Next(2) + 1;
			switch(j){
				case 1:
					Enemy enemy = new Enemy("スライム", 15, 10, 2, 10, 15, 5);
					break;

				case 2:
					Enemy enemy2 = new Enemy("ゴブリン",30 , 10, 2, 10, 15, 5);
					break;
			}

		}
		public void EnemylevelUp()
		{
			LevelUp();
			GainExp *= 2;
			GainGold *= 2;
		}

	}
}
