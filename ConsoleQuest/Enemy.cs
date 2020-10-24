using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Enemy : Character
	{
		public int GainExp
		{ get; private set; }

		public int GainCoin 
		{ get; private set; }

		public Enemy(string name, float maxHP, float attackPoint, float defencePoint, float mp,float ing,
			int gainExp, int gainCoin)
			: base(name, maxHP, attackPoint, defencePoint, mp, ing)
		{
			GainExp = gainExp;
			GainCoin = gainCoin;
		}


	}
}
