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

		public  Enemy EnemyBattle()
        {
			Random er = new Random();//敵のランダム出現
			int enemynum = er.Next(2) + 1;
			Enemy enemy = new Enemy(" ", 0, 0, 0, 0, 0, 0);
			switch (enemynum){
				case 1:
					enemy = new Enemy("スライム", 15, 10, 2, 10, 15, 5);
					break;

				case 2:
					enemy = new Enemy("ゴブリン",30 , 10, 2, 10, 15, 5);
					break;
			}
			return enemy;
		}
		public void LevelUpEnemy()
		{
			EnemylevelUp();
			GainExp += 10;
			GainGold += 5;
		}

	}
}
