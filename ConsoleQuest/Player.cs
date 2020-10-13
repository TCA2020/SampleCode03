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

		public Player(string name, float maxHP, float attackPoint, float defencePoint,
			int level, int exp)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			Level = level;
			Exp = exp;
		}

		//経験値、レベルアップ処理
		public int GetExp(int exp)
		{
			Exp += exp;
			return Exp;
			//if(Exp > 
		}

	}
}
