﻿using System;
using System.Collections.Generic;
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
			if (Exp >= masterDate.Exptable(Level))
			{
				Level++;
			}
			return tf;
		}

		//HPを最大HPの4分の1回復する
		public float HPheal(float hp,float maxhp)
        {
			float heal = hp + (float)Math.Round((maxhp / 4));
			return heal ;
		}

		//キャラデータ出力
		public string ExportJson(string Export)
        {


			//Export = Newtonsoft.Json.JsonConvert.SerializeObject();

			return Export;
        }

	}
}
