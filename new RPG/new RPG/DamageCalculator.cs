using System;
using System.Collections.Generic;
using System.Text;

namespace new_RPG
{
	public static class DamageCalculator
	{
		//ランダム計算機。一度生成したら使い回す
		private static Random RandomGenerator = new Random();

		


		/// <summary>
		/// ダメージ計算を行う
		/// </summary>
		/// <param name="attacker">攻撃側キャラ</param>
		/// <param name="target">防御側キャラ</param>
		/// <returns>ダメージ値</returns>
		public static float CalculateDamage(Soldier player, Soldier target)
		{
			// ドラクエの計算式にならう
			//（攻撃力-守備力/4）×乱数(7/8~9/8)
			float damage = (player.Attack / 2 - target.Defence / 4) * (0.875f + (float)RandomGenerator.NextDouble() * 0.25f);

			//小数点切り捨て
			damage = (float)Math.Floor(damage);
			//最低ダメージ保証
			if (damage < 1f) damage = 1f;

			return damage;
		}

		//一段目のダメージ
		public static float HeroSwordSkillDamage1(Soldier player,Soldier target)
		{
			float swordskilldamage1 = (player.Attack*1.5f - target.Defence / 3) * (0.875f + (float)RandomGenerator.NextDouble() * 0.35f);

			swordskilldamage1 = (float)Math.Floor(swordskilldamage1);

			if (swordskilldamage1 < 1f) swordskilldamage1 = 1f;

			return swordskilldamage1;
		}
		//二段目のダメージ
		public static float HeroSwordSkillDamage2(Soldier player, Soldier target)
		{
			float swordskilldamage2 = (player.Attack * 1.5f - target.Defence / 3) * (0.875f + (float)RandomGenerator.NextDouble() * 0.35f);

			swordskilldamage2 = (float)Math.Floor(swordskilldamage2);

			if (swordskilldamage2 < 1f) swordskilldamage2 = 1f;

			return swordskilldamage2;
		}

		public static float HeroFinalSkillDamage(Soldier player,Soldier target)
		{
			float herofinalskilldamage = (player.Attack * 5 - target.Defence / 8) * (0.8f + (float)RandomGenerator.NextDouble() * 0.5f);
			
			herofinalskilldamage = (float)Math.Floor(herofinalskilldamage);

			return herofinalskilldamage;
		}

		public static float BossSkill1Damage(Soldier boss,Soldier target)
        {
			float bossskill1damage = (boss.Attack * 2 - target.Defence / 4) * (0.7f + (float)RandomGenerator.NextDouble() * 0.4f);

			bossskill1damage = (float)Math.Floor(bossskill1damage);

			return bossskill1damage;
		}

		public static float BossSkill2Damage(Soldier boss, Soldier target)
		{
			float bossskill2damage = (boss.Attack * 3 - target.Defence / 3) * (0.75f + (float)RandomGenerator.NextDouble() * 0.5f);

			bossskill2damage = (float)Math.Floor(bossskill2damage);

			return bossskill2damage;
		}

		public static float BossFinalSkillDamage(Soldier boss, Soldier target)
		{
			float bossfinalskilldamage = ((boss.Attack * 4 - target.Defence / 2) * (0.7f + (float)RandomGenerator.NextDouble() * 0.5f));

			bossfinalskilldamage = (float)Math.Floor(bossfinalskilldamage);

			return bossfinalskilldamage;
		}


	}
}
