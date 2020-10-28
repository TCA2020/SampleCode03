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

		public float Potion
		{ get; private set; }

		public Player(string name, float maxHP,float hp, float attackPoint, float defencePoint,
			int level, int exp, float potion)
			: base(name, maxHP, hp, attackPoint, defencePoint)
		{
			Potion = potion;
			Level = level;
			Exp = exp;
		}

	}
}
