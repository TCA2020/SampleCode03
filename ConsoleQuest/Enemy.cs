using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Enemy : Character
	{
		public int GainExp
		{ get; private set; }

		public Enemy(string name, float maxHP, float attackPoint, float defencePoint,
			int gainExp)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			GainExp = gainExp;
		}

		public  EnemyBattle()
        {
			System.Random random = new Random();//敵のランダム出現
			int j = random.Next(2) + 1;

            if (j == 1)
            {
				Enemy enemy = new Enemy("敵", 30, 10, 2, 10);
            }
            else
            {
				Enemy enemy = new Enemy("敵2", 30, 10, 2, 10);
			}

			return;
		}

	}
}
