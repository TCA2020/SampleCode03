using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Dynamic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{

		public int Level
		{ get; private set; }

		public double Next 
		{ get; private set; }
		public float Exp
		{ get; private set; }

		public float Coin 
		{ get; private set; }

		public float HealNum 
		{ get; private set; }


		public Player(string name, float maxHP, float atk, float def, float maxmp, float preing,
			int level, float exp,float heal,float coin,double next)
			: base(name, maxHP, atk, def, maxmp , preing)
		{
			Level = level;
			Next = next;
			Exp = exp;
			HealNum = heal;
			Coin = coin;
		}
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
				
			Exp += target.GainExp;
			//レベルアップの有無
			if (Exp >= Next)
			{
				Logger.Log("レベルアップ\n");
				this.Exp = this.Exp - (float)Next;
				Level++;
				Logger.Log(this.Exp);
				Logger.Log("Lv" + (Level - 1) + "->Lv" + Level);

				float Before = (float)Next;

				Next = Math.Floor(Before * (float)1.1);
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
