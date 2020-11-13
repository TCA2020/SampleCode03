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

		/*public strongEnemy(string boss, float maxHP, float attackPoint, float defencePoint,
			int gainExp)
		
			: base(boss, maxHP+20, attackPoint+10, defencePoint + 15) 
		{
			GainExp = gainExp;

			return;
		}*/

	}
}
