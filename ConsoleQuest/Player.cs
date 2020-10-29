using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{

		public float Playing
		{ get; set; }

		public int Level
		{ get; set; }

		public int Exp
		{ get; set; }

		public float MaxExp
		{ get; set; }

		public List<string> Item
		{ get; set; }

		public int Gold
		{ get; set; }

		public Player(string name, float maxHP, float atk, float def, float maxMP,float playing,
			int level, int exp,float maxexp,List<string> item,int gold)
			: base(name, maxHP, atk, def,maxMP)
		{
			Playing = playing;
			Level = level;
			Exp = exp;
			MaxExp = maxexp;
			Item = item;
			Gold = gold;
		}

		public float MagicAttack(Character target)
		{
			MP -= 5;
			ATK *= 2;
			float damage = DamageCalculator.CalculateDamage(this, target);
			ATK /= 2;
			target.HP -= damage;
			return damage;
        }

		public void EXPCalc(Enemy target )
		{
			Exp+=target.GainExp;
			if ( Exp >=MaxExp )
			{
				float nextExp = 0;
				Level+=1;
				Logger.Log(Name+"はLevel" +Level+"になった");
                if (Exp > MaxExp)
                {
					nextExp = Exp - MaxExp;
                }
				Exp=0+(int)nextExp;
				MaxExp *= 2;
				LevelUp();
			}
		}
		public void GoldCalc(Enemy target)
        {
			Gold += target.GainGold;
        }


		/*public void Shop()
        {
			int action = 0;
			Logger.Log("いらっしゃいませ！\n1=薬草:15G\n2=ポーション:30G");
			action = int.Parse(Console.ReadLine());

			switch(action)
            {
				case 1:
					Logger.Log("薬草を購入しました。");
					Item = List<string>(){ "薬草"};
            }
		}					
		
		public int Countchar(string item,char cout)
        {
			return item.Length - item.Replace(cout.ToString(), "").Length;
        }*/

	}
}
