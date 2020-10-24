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

		public float MaxMP 
		{ get; private set; }
		public float MP 
		{ get; private set; }

		public float Preing
		{ get; private set; }


		public Character(string name, float maxHP, float atk, float def, float maxmp, float praing)
		{
			Name = name;
			MaxHP = maxHP;
			HP = maxHP;
			ATK = atk;
			DEF = def;
			MaxMP = maxmp;
			MP = maxmp;
			Preing = praing;
		}


		public float Attack(Character target)
		{
			float damage = DamageCalculator.CalculateDamage(this, target);
			target.HP -= damage;

			return damage;
		}

		public float PowerAttack(Character target)
		{
			MP = MP - 10;
			ATK = ATK * 2;
			float damage = DamageCalculator.CalculateDamage(this, target);
			ATK = ATK / 2;
			target.HP = target.HP - damage;
			return damage;
		}

		public float Defend(Character target)
		{
			target.DEF = target.DEF * 2;

			float damage = DamageCalculator.CalculateDamage(this, target);
			target.DEF = target.DEF / 2;
			target.HP -= damage;
			return damage;
		}
		public float CharaHeal( Character player)
		{
			float healPoint = 0;
			healPoint = player.MaxHP * (float)0.2;
			player.HP = player.HP + healPoint;
			if (player.HP > player.MaxHP)
			{
				player.HP = player.MaxHP;
			}
			return healPoint;
		}

		public void LevelUP()
		{
			MaxHP = MaxHP + 10;
			MaxMP = MaxMP + 10;
			MP = MaxMP;
			ATK++;
			DEF++;
		}

	}
}
