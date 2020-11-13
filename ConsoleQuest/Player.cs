using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{

		public float Level
		{ get; private set; }

		public float exp
		{ get; private set; }

		public float maxhp
		{ get; private set; }

		public float attackpoint
		{ get; private set; }

		public float defencepoint
		{ get; private set; }

		public double Next 
		{ get; private set; } 

		public Player(string name, float maxHP, float attackPoint, float defencePoint,
		float level, float exp,double next)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			Level = level;
			this.exp = exp;
			attackpoint = attackPoint;
			maxhp = maxHP;
			defencepoint = defencePoint;
			Next = next;
		}

		public void LEVELUP(Enemy target)
		{
			exp += target.GainExp;
			if (exp >= Next) 
			{
				LevelSystem();			
			}
		}

		public void LevelSystem() 
		{
			Logger.Log("レベルアップ\n");
			Level++;
			Logger.Log("Lv" + (Level - 1) + ("->lv") + Level);
			Status();

			float Before = (float)Next;
			exp = exp - Before;

			Next = Math.Truncate(Before * 1.3);
			if (exp >= Next) 
			{
				LevelSystem();
			}
		}

		public Player(PlayerSaveData data)
			:base(data.Name,data.MaxHP,data.AttackPoint,data.DefencePoint)
		{
			Level = data.Level;
			exp = data.EXp;
			HP = data.HP;
		}

	}
}
