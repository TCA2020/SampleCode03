using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleQuest
{
	public class Player : Character
	{
		public int Level
		{ get; private set; }

		public int Exp
		{ get; private set; }

		public Player(string name, float maxHP, float attackPoint, float defencePoint,
			int level, int exp)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			Level = level;
			Exp = exp;
		}

		//経験値、レベルアップ処理
		public int GetExp(int exp)
		{
			Exp += exp;
			return Exp;
		}

		public bool LvUp()
        {
			bool tf = true;
			if (Level <= 30)
			{
				if (Exp >= masterDate.Exptable(Level))
				{
					Level++;
					Exp = 0;
				}
				else
				{
					tf = false;
				}
            }
            else
            {
				tf = false;
            }
			return tf;
		}

		//HPを最大HPの4分の1回復する
		public float HPheal(float hp,float maxhp)
        {
			float heal = hp + (float)Math.Round((maxhp / 4));
			if(heal >= maxhp)
			{
				heal = 100;
			}
			return heal ;
		}

		/*public Player(PlayerSaveDate date)
			:base(date.Name,date.maxHP,date.AttackPoint,date.Difencepoint)
		{
			Level = date.level;
			Exp = date.Exp;
			HP = date.maxHP;
		}*/

		//キャラデータ出力
		public bool ExportJson()
        {
			bool tof = true;

			Program Export = new Program();
			//Export.SaveUserJson(Player data, string path);


			return tof;
        }
		public float deathheal()
		{
			return this.HP = this.MaxHP;
		}
	}
}
