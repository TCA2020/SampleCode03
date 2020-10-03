using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	class Enemy : Character
	{
		public int GainExp
		{ get; private set; }

		public Enemy(float maxHP, float attackPoint, float defencePoint,
			int gainExp)
			: base(maxHP, attackPoint, defencePoint)
		{
			GainExp = gainExp;
		}


	}
}
