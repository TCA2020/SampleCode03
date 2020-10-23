using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{

		public float Playing
		{ get; private set; }

		public int Level
		{ get; private set; }

		public int Exp
		{ get; private set; }

		public float MaxExp
		{ get; private set; }

		public Player(string name, float maxHP, float atk, float def,float playing,
			int level, int exp,float maxexp)
			: base(name, maxHP, atk, def)
		{
			Playing = playing;
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
				player.MaxExp *= 2;
			}
			return Level;
		}

	}
}
