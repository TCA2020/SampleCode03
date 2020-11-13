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

		public Player(string name, float maxHP, float attackPoint, float defencePoint,float Maxmp,
			int level, int exp)
			: base(name, maxHP, attackPoint, defencePoint,Maxmp)
		{
			Level = level;
			Exp = exp;
		}
		public Player(PlayerSaveData data)
			: base(data.Name, data.MaxHP, data.AttackPoint, data.DefencePoint,data.MaxMP)
		{
			Level = data.Level;
			Exp = data.Exp;
			HP = data.HP;
		}

        public Player(string name, float maxHP, float attackPoint, float defencePoint, float Maxmp, int v) : base(name, maxHP, attackPoint, defencePoint, Maxmp)
        {
        }
    }
}
