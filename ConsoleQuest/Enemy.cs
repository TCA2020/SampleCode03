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


	}

	public class copyEnemy
	{
		public Enemy Enemy;
	}
}
