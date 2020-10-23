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
		public float Preing
		{ get; private set; }


		public Character(string name, float maxHP, float attackPoint, float defencePoint, float praing)
		{
			Name = name;
			MaxHP = maxHP;
			HP = maxHP;
			ATK = attackPoint;
			DEF = defencePoint;
			Preing = praing;
		}


		public float Attack(Character target)
		{
			float damage = DamageCalculator.CalculateDamage(this, target);
			target.HP -= damage;

			return damage;
		}
		
		public float Defend_Attack(Character target)
		{
			float damage = DamageCalculator.DefendCalculateDamage(this, target);
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

		public void LevelUP(Character player)
		{
			player.MaxHP = MaxHP + 10;
			player.ATK++;
			player.DEF++;
		}

	}
}
