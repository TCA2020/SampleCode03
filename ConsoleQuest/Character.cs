using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Character
	{
		public string Name
		{ get; private set; }

		public float MaxHP
		{ get; private set; }

		public float HP
		{ get; private set; }

		public bool IsAlive
		{ get { return HP > 0; } }

		public float ATK
		{ get; private set; }

		public float DEF
		{ get; private set; }


		public Character(string name, float maxHP, float attackPoint, float defencePoint)
		{
			Name = name;
			MaxHP = maxHP;
			HP = maxHP;
			ATK = attackPoint;
			DEF = defencePoint;
		}


		public float Attack(Character target)
		{
			float damage = DamageCalculator.CalculateDamage(this, target);

			target.HP -= damage;
			return damage;
		}


	}
}
