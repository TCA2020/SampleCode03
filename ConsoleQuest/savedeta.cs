using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    class savedeta
    {
		public PlayerSaveDeta Player;

	}
	public class PlayerSaveDeta
	{
		public string Name;
		public float MaxHP;
		public float HP;
		public bool IsAlive;
		public float AttackPoint;
		public float DefencePoint;

		public int Level;
		public int Exp;
	}
}
