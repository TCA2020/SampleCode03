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

		public int MaxExp
		{ get; private set; }

		public Player(string name, float maxHP, float attackPoint, float defencePoint,
			int level, int exp,int maxexp)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			Level = level;
			Exp = exp;
			MaxExp = maxexp;
		}

		public float LevelUp(Player player,Enemy enemy )
		{
			player.Exp+=enemy.GainExp;
			if ( player.Exp >= player.MaxExp )
			{
				player.Level+=1;
				Logger.Log(player.Name+"はLevel" +player.Level+"になった");
				player.Exp=0;
			}
			return Level;
		}

	}
}
