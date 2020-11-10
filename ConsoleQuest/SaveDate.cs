using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    class SaveDate
    {
        public PlayerSaveDate Player;
    }

    public class PlayerSaveDate
    {
        public string Name;
        public float maxHP;
        public float HP;
        public float AttackPoint;
        public float Difencepoint;

        public int level;
        public int Exp;
    }
}
