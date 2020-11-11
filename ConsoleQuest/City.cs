using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    public class City
    {
        private Player Cplayer;

        public City(Player player)
        {
            Cplayer = player;
        }
        public Cityarea ActionTurn()
        {
            int action = 0;

            Logger.Log("どこに行きますか？\n1=宿屋\n2=街を出る");
            action = Try_Catch();
            switch (action)
            {
                case 1:   //宿屋
                    Logger.Log("宿屋へようこそ\n一泊30Gです。お泊りになりますか？\n1=はい\n2=いいえ");
                    int Y_action = Try_Catch();
                    if (Y_action == 1)
                    {
                        if (Cplayer.Gold >= 30)
                        {
                            INN(Cplayer);
                            Logger.Log("ご利用ありがとうございました。");
                        }
                        else
                        {
                            Logger.Log("お金が足りません。");
                        }
                    }
                    Logger.Log("またお越しください。");
                    return Cityarea.Continue;

                case 2:
                    Logger.Log("街を後にした。");
                    break;

            }
            return Cityarea.finish;
        }
        public void INN(Player player)
        {
            player.Gold -= 30;
            player.HP = player.MaxHP;
            player.MP = player.MaxMP;
            Logger.Log("HP:" + player.HP + "/" + player.MaxHP + "\nMP:" + player.MP + "/" + player.MaxMP);
        }

        int Try_Catch()
        {
            int action;
            try
            {
                action = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                action = 0;
                return action;
            }
            finally
            {
                Console.Clear();
            }
            return action;
        }
    }
    public enum Cityarea
    {
        Continue,
        finish,
    }
}
