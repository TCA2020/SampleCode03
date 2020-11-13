using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
  
        public class Savedata 
        {
            public PlayerSaveData Player;
        }

        public class PlayerSaveData 
        {
            public string Name;
            public float MaxHP;
            public float HP;
            public float AttackPoint;
            public float DefencePoint;

            public int Level;
            public int EXp;
        }
}
