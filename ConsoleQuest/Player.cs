using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{
		public int Level
		{ get; private set; }

		public int Exp
		{ get; private set; }

		public Player(float maxHP, float attackPoint, float defencePoint,
			int level, int exp)
			: base(maxHP, attackPoint, defencePoint)
		{
			Level = level;
			Exp = exp;
		}

	}
}
