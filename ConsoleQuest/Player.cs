using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{

		public int Level
		{ get; private set; }

		public float Exp
		{ get; private set; }

		public float Coin 
		{ get; private set; }

		public float HealNum 
		{ get; private set; }


		public Player(string name, float maxHP, float attackPoint, float defencePoint, float preing,
			int level, float exp,float heal,float coin)
			: base(name, maxHP, attackPoint, defencePoint, preing)
		{
			Level = level;
			Exp = exp;
			HealNum = heal;
			Coin = coin;
		}

		float Before = 0;
		double next = 10;
		public float Heal(Character player )
		{
			float healPoint = 0;
			HealNum--;
			healPoint = player.CharaHeal(player);

			return healPoint;
		}

		public void GetCoin(Enemy enemy)
		{
			Coin += enemy.GainCoin;
		}

		public bool EXPCall(Enemy target)
		{
			//必要経験値の上昇
			if (Level > 1)
			{
				
				Before = (float)next;

				next = Math.Floor(Before * (float)1.1);
			}
			Exp += target.GainExp;
			//レベルアップの有無
			if (Exp >= next)
			{
				Logger.Log("レベルアップ\n");
				Exp = Exp - (float)next;
				Level++;
				Logger.Log(Exp);
				Logger.Log("Lv" + (Level - 1) + "->Lv" + Level);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void GetHeal()
		{
			Coin -= 50;
			HealNum += 1;
		}


	}
}
