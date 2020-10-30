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
			int level, float exp,float healnum,float coin,double next)
			: base(name, maxHP, atk, def, maxmp , preing)
		{
			Level = level;
			Next = next;
			Exp = exp;
			HealNum = healnum;
			Coin = coin;
		}
		public void Heal(Character player )
		{
			HealNum--;
			player.CharaHeal(player);

		}

		public void GetCoin(Enemy enemy)
		{
			Coin += enemy.GainCoin;
		}

		public void EXPCall(Enemy target)
		{
			//経験値の付与
			Exp += target.GainExp;
			//レベルアップの有無
			if (Exp >= Next)
			{
				LevelSystem();
			}
		}

		public void LevelSystem()
		{
			Logger.Log("レベルアップ\n");
			Level++;
			Logger.Log("Lv" + (Level - 1) + "->Lv" + Level);
			//ステータス上昇
			LevelUP();

			float Before = (float)Next;
			Exp = Exp - Before;

			//必要経験値の上昇
			Next = Math.Truncate(Before * (float)1.3);
			//レベルアップの有無
			if (Exp >= Next)
			{
				LevelSystem();
			}
		}

		public void GetHeal()
		{
			Coin -= 50;
			HealNum += 1;
		}


	}
}
