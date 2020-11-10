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

		public Enemy(string name, float maxHP,float hp, float attackPoint, float defencePoint, float Maxmp,float mp,float ing,
			int gainExp, int gainCoin)
			: base(name, maxHP,hp, attackPoint, defencePoint,Maxmp, mp, ing)
		{
			GainExp = gainExp;
			GainCoin = gainCoin;
		}

		public void LvUpEnemy()
		{
			GainCoin = GainCoin + 10;
			GainExp = GainExp + 5;
			EnemyUP();
		}


	}
}
