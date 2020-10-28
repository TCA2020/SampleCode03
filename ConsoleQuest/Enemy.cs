using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Enemy : Character
	{
		public int GainExp
		{ get; private set; }

		public Enemy(string name, float maxHP, float hp, float attackPoint, float defencePoint,
			int gainExp)
			: base(name, maxHP, hp, attackPoint, defencePoint)
		{
			GainExp = gainExp;
		}


	}
}
