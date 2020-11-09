using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{

		public int Level
		{ get; set; }

		public int Exp
		{ get; set; }

		public Player(string name, float maxHP, float attackPoint, float defencePoint,
			int level, int exp)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			Level = level;
			Exp = exp;
		}

		int exp_table(int level)
		{

			int cap = 50;
			int[] exptable = new int[cap];
			for (int i = 0; i < cap; i++)
			{
				if (i < 10)
				{
					exptable[i] = (i + 1) * 12 - 2;

				}
				else if (i > 10)
				{
					exptable[i] = (i + 1) * 15;

				}
			}
			return exptable[level - 1];


		}

		public void Get_expLVL(Enemy target)
		{
			this.Exp = target.GainExp + this.Exp;
			if (this.Exp >= exp_table(this.Level))
			{
				this.Exp -= exp_table(this.Level);
				this.Level++;
				Logger.Log("Level Up!!");
				this.HP = this.MaxHP;

			}
		}


	}
}
