using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Character
	{
		public float MaxHP
		{ get; private set; }

		public float HP
		{ get; private set; }

		public float AttackPoint
		{ get; private set; }

		public float DefencePoint
		{ get; private set; }


		public Character(float maxHP, float attackPoint, float defencePoint)
		{
			MaxHP = maxHP;
			HP = maxHP;
			AttackPoint = attackPoint;
			DefencePoint = defencePoint;
		}


		public float Attack(Character target)
		{
			float damage = DamageCalculator.CalculateDamage(this, target);

			target.HP -= damage;
			return damage;
		}


	}
}
