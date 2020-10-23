using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{

		public int Level
		{ get; private set; }

		public float Exp
		{ get; private set; }

		public Player(string name, float maxHP, float attackPoint, float defencePoint, float preing,
			int level, float exp)
			: base(name, maxHP, attackPoint, defencePoint, preing)
		{
			Level = level;
			Exp = exp;
		}
		public void EXPCall(Enemy target)
		{
			float Before= 0;
			double next = 10;
			Before = (float)next;
			next = Math.Truncate(Before * (float)1.1);
			Exp += target.GainExp;
			if(Exp >= next)
			{
				Logger.Log("レベルアップ\n");
				Exp = (float)next - Exp;
				Level++;
				Logger.Log("Lv" + (Level - 1) + "->Lv" + Level);
				
			}

			return;
		}

	}
}
