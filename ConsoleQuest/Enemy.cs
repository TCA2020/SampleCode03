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


		}

	}
}
