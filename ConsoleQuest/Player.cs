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

		public Player(string name, float maxHP, float attackPoint, float defencePoint, List<string> items, Weapon weapon,
			int level, int exp)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			Level = level;
			Exp = exp;
		}

		public Player(PlayerSaveDeta data)
			:base(data.Name,data.MaxHP,data.AttackPoint,data.DefencePoint)
		{
			Level = data.Level;
			Exp = data.Exp;
			this.HP = data.HP;
		}

		public float LevelUp(Player player,Enemy enemy)
		{
			player.Exp += enemy.GainExp;
			if(player.Exp>=40)
			{
				player.Level += 1;
				Logger.Log(player.Name + "はLevel" + player.Level + "になった");
				player.Exp = 0;
				LevelUP();
			}
			return Level;
		}

	}
}
