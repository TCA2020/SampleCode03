using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Weapon
	{
		public string Name;

		public float WATK
		{ get; set; }

		public Weapon(string name, float watk)
		{
			Name = name;
			WATK = watk;
		}
	}
}
