using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    public class Battle
    {
        private Player BattlePlayer;
        private Enemy BattleEnemy;
        private string Choise;
        private int Choose;
        private int Limit = 3;

        public Battle(Player player,Enemy enemy)
        {
            BattlePlayer = player;
            BattleEnemy = enemy;
        }

        /*<summary>*/
        /*ターンを進める*/
        /*</summary>*/
        /*<returns>処理終了後のバトル状況</returns>*/
        public BattleState AdvanceTurn()
        {
            Logger.Log(BattlePlayer.Name + "はどうする？");
            Logger.Log("1.戦う 2.回復する(残り"+Limit+"回)");
            Choise = Logger.ReadInput();
            int.TryParse(Choise,out Choose);
            if (Choose == 1)
            {
                /*プレイヤーと敵が殴り合う*/
                float damage = BattlePlayer.Attack(BattleEnemy);
                Logger.Log(BattlePlayer.Name + "の攻撃:" + BattleEnemy.Name + "に" + damage + "のダメージ");



                if (!BattleEnemy.IsAlive)
                {
                    Logger.Log(BattleEnemy.Name + "を倒した！");
                    return BattleState.Win;
                }

                damage = BattleEnemy.Attack(BattlePlayer);
                Logger.Log(BattleEnemy.Name + "の攻撃" + BattlePlayer.Name + "に" + damage + "のダメージ");
                Logger.Log("敵のHPは" + BattleEnemy.HP + "/" + BattleEnemy.MaxHP);
                Logger.Log(BattlePlayer.Name + "のHPは" + BattlePlayer.HP + "/" + BattlePlayer.MaxHP);

                if (!BattlePlayer.IsAlive)
                {
                    Logger.Log(BattlePlayer.Name + "は倒れた…");
                    return BattleState.Lose;
                }
            }
            else if (Choose == 2) {
                if (Limit >= 0)
                {
                    float heal = BattlePlayer.Heal(BattlePlayer);
                    Logger.Log(BattlePlayer.Name + "は回復した！");
                    Logger.Log(BattlePlayer.Name + "のHPは" + BattlePlayer.HP + "/" + BattlePlayer.MaxHP);
                    Limit--;
                    Logger.Log("あと" + Limit + "回回復できるぞ！");
                    
                }
				else
				{
                    Logger.Log("これ以上回復できない！！");
				}
            }
            return BattleState.Continue;
        }
    }

    public enum BattleState
    {
        Win,
        Lose,
        Continue,
    }
}
