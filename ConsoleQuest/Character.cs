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


		public Character(string name, float maxHP,float hp, float atk, float def, float maxmp,float mp, float praing)
		{
			Name = name;
			MaxHP = maxHP;
			HP = hp;
			ATK = atk;
			DEF = def;
			MaxMP = mp;
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
		public void CharaHeal( Character player)
		{
			double healPoint = 0;
			healPoint = Math.Truncate( player.MaxHP * 0.4);

			player.HP = player.HP + (float)healPoint;
			if (player.HP > player.MaxHP)
			{
				player.HP = player.MaxHP;
			}
			Logger.Log(player.Name + "は" + healPoint + "回復した");
		}

		public void LevelUP()
		{
			MaxHP = MaxHP + 10;
			MaxMP = MaxMP + 2;
			MP = MaxMP;
			ATK++;
			DEF++;
		}

		public void EnemyUP()
		{
			MaxHP = MaxHP + 40;
			HP = MaxHP;
			MaxMP = MaxMP + 20;
			MP = MaxMP;
			ATK = ATK + 7;
			DEF = DEF + 3;
		}

	}
}
