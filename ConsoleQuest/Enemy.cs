using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Enemy : Character
	{
		public int GainExp
		{ get; set; }
		public int GainGold
		{ get; set; }

		public Enemy(string name, float maxHP, float atk, float def, float maxMP,
			int gainExp,int gainGold)
			: base(name, maxHP, atk, def, maxMP)
		{
			GainExp = gainExp;
			GainGold = gainGold;
		}

		public void LevelUpEnemy()
		{
			EnemylevelUp();
			GainExp += 10;
			GainGold += 5;
		}

	}
}
