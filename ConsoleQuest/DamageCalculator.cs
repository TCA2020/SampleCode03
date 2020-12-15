using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
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
        public static float CalculateDamage(Character attacker, Character target)
        {
            // ドラクエの計算式にならう
            //（攻撃力/2-守備力/4）×乱数(7/8~9/8)
            float damage = (attacker.AttackPoint / 2 - target.DefencePoint / 4) * (0.875f + (float)RandomGenerator.NextDouble() * 0.25f);
            //小数点切り捨て
            damage = (float)Math.Floor(damage);
            //最低ダメージ保証
            if (damage < 1f) damage = 1f;

            return damage;
        }
    }
}
