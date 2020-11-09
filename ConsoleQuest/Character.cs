using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Character
	{
		public string Name
		{ get; set; }

		public float MaxHP
		{ get;  set; }

		public float HP
		{ get;  set; }

		public bool IsAlive
		{ get { return HP > 0; } }

		public float AttackPoint
		{ get; set; }

		public float DefencePoint
		{ get; set; }

		public Character()
		{

		}

		public Character(string name, float maxHP, float attackPoint, float defencePoint)
		{
			Name = name;
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
