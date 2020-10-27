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
		{ get; set; }

		public float HP
		{ get; set; }

		public float MaxMP
		{ get; set; }

		public float MP
		{ get; set; }

		public bool IsAlive
		{ get { return HP > 0; } }

		public float ATK
		{ get; set; }

		public float DEF
		{ get; set; }

		


		public Character(string name, float maxHP, float atk, float def, float maxMP)
		{
			Name = name;
			MaxHP = maxHP;
			HP = maxHP;
			MaxMP = maxMP;
			MP = maxMP;
			ATK = atk;
			DEF = def;
		}


		public float NormalAttack(Character target)
		{
			float damage = DamageCalculator.CalculateDamage(this, target);

			target.HP -= damage;
			return damage;
		}

		public float Defense(Character target)
        {
			target.DEF *= 2;
			float damage = DamageCalculator.CalculateDamage(this, target);

			target.DEF /= 2;
			target.HP -= damage;
			return damage;
		}


		public void LevelUp()
        {
			MaxHP += 10;
			HP = MaxHP;
			MaxMP += 5;
			ATK+=2;
			DEF++;
        }
	}
}
